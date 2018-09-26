using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Editor.Core;
using Varguiniano.ScriptableCore.Persistence;

namespace Varguiniano.ScriptableCore.Editor.Persistence
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for the persistence utility.
    /// </summary>
    [CustomEditor(typeof(PersistenceUtility))]
    public class PersistenceUtilityEditor : ScriptableObjectEditor
    {
        /// <summary>
        /// Reference to the utility being edited.
        /// </summary>
        private PersistenceUtility Utility => (PersistenceUtility) target;

        /// <summary>
        /// Flag to know if the given folder is in the project.
        /// </summary>
        private bool givenFolderIsNotInProject;

        /// <inheritdoc />
        /// <summary>
        /// Paints the interface.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                if (GUILayout.Button("Save objects"))
                    Utility.SaveToFiles();
                if (GUILayout.Button("Load objects"))
                    Utility.LoadFromFiles();

                GUILayout.Space(15);

                PaintProperty("PersisterName");

                GUILayout.Space(15);

                EditorGUILayout.HelpBox(
                    "NEVER modify the list between saving and loading, it will definitely break things. " +
                    "If you modify the list, save again.", MessageType.Warning);

                if (GUILayout.Button("Add entire folder to list (recursive)"))
                    AddToListObjectsInFolder();
                if(givenFolderIsNotInProject)
                    EditorGUILayout.HelpBox("That folder is not part of the project!", MessageType.Error);

                PaintProperty("ObjectsToPersist", true);
            }
            if (!EditorGUI.EndChangeCheck()) return;
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
            EditorUtility.SetDirty(Utility);
        }

        /// <summary>
        /// Adds to the list all scriptable objects in a folder.
        /// </summary>
        private void AddToListObjectsInFolder()
        {
            var path = EditorUtility.OpenFolderPanel("Choose scriptable objects location", "", "");
            if (string.IsNullOrEmpty(path)) return;

            if (!path.StartsWith(Application.dataPath))
            {
                givenFolderIsNotInProject = true;
                return;
            }

            givenFolderIsNotInProject = false;

            var paths = Directory.GetFiles(path, "*.asset", SearchOption.AllDirectories);

            var assets = new List<PersistentScriptableObject>();
            foreach (var filePath in paths)
            {
                string relativePath;
                if (filePath.StartsWith(Application.dataPath))
                    relativePath = "Assets" + filePath.Substring(Application.dataPath.Length);
                else
                    continue;
                var newAsset = AssetDatabase.LoadAssetAtPath<PersistentScriptableObject>(relativePath);
                if (newAsset != null)
                    assets.Add(newAsset);
            }

            foreach (var asset in assets)
                if (!Utility.ObjectsToPersist.Contains(asset))
                    Utility.ObjectsToPersist.Add(asset);

            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
            EditorUtility.SetDirty(Utility);
            AssetDatabase.SaveAssets();
            Repaint();
        }
    }
}