using UnityEditor;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Primitives;

namespace Varguiniano.ScriptableCore.Editor.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for float variable.
    /// </summary>
    [CustomEditor(typeof(FloatVariable))]
    public class FloatVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private FloatVariable variable;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            variable = (FloatVariable) target;

            EditorGUI.BeginChangeCheck();
            {
                variable.Value = EditorGUILayout.FloatField("Value", variable.Value);

                variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(variable);
        }
    }
}