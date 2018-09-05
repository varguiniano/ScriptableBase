using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.DataStructures;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Editor.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for GameObject variable.
    /// </summary>
    [CustomEditor(typeof(GameObjectVariable))]
    public class GameObjectVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private GameObjectVariable Variable => (GameObjectVariable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.Value =
                    (GameObject) EditorGUILayout.ObjectField("Value", Variable.Value, typeof(GameObject), true);

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}