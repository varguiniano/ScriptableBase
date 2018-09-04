using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.DataStructures;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Editor.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for Vector3 variable.
    /// </summary>
    [CustomEditor(typeof(Vector3Variable))]
    public class Vector3VariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private Vector3Variable variable;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            variable = (Vector3Variable) target;

            EditorGUI.BeginChangeCheck();
            {
                variable.Value = EditorGUILayout.Vector3Field("Value", variable.Value);

                variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(variable);
        }
    }
}