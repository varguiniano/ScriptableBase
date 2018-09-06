using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Localization;

namespace Varguiniano.ScriptableCore.Editor.Localization
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for the language manager Scriptable Object.
    /// </summary>
    [CustomEditor(typeof(LanguageManager))]
    public class LanguageManagerEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the language manager being edited.
        /// </summary>
        private LanguageManager manager;

        /// <summary>
        /// Id to look for in the quick translate field.
        /// </summary>
        private string quickId;

        /// <inheritdoc />
        /// <summary>
        /// Custom UI.
        /// </summary>
        public override void OnInspectorGUI()
        {
            manager = (LanguageManager) target;
            
            EditorGUI.BeginChangeCheck();
            {
                if (manager.AllLanguages.Length > 1)
                    manager.CurrentLanguageId = EditorGUILayout.Popup("Current language", manager.CurrentLanguageId,
                        manager.AllLanguages);
                else
                {
                    EditorGUI.BeginDisabledGroup(true);
                    {
                        EditorGUILayout.LabelField("Current language", manager.CurrentLanguage);
                    }
                    EditorGUI.EndDisabledGroup();
                }

                GUILayout.Space(30);

                manager.OnLanguageChanged = (GameEvent) EditorGUILayout.ObjectField("On language changed event",
                    manager.OnLanguageChanged, typeof(GameEvent), false);

                GUILayout.Space(30);

                if (manager.AllLanguages.Length > 0)
                    QuickTranslate();

                GUILayout.Space(30);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(manager);

            DisplayLanguageArray();
        }

        /// <summary>
        /// Displays the languages array as it would show in a normal inspector.
        /// </summary>
        private void DisplayLanguageArray()
        {
            var property = serializedObject.FindProperty("languages");
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(property, true);
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Tool for quick translating.
        /// </summary>
        private void QuickTranslate()
        {
            GUILayout.BeginHorizontal();
            {
                quickId = EditorGUILayout.TextField("Quick translate", quickId);
                GUILayout.TextField(manager[quickId]);
            }
            GUILayout.EndHorizontal();
        }
    }
}