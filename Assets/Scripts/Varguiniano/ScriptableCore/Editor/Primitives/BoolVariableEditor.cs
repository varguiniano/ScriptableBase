using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Primitives;

namespace Varguiniano.ScriptableCore.Editor.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for bool variable.
    /// </summary>
    [CustomEditor(typeof(BoolVariable))]
    public class BoolVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private BoolVariable variable;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            variable = (BoolVariable) target;

            EditorGUI.BeginChangeCheck();
            {
                variable.Value = EditorGUILayout.Toggle("Value", variable.Value);

                variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(variable);
        }
    }
}