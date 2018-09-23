using UnityEditor;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Primitives;

namespace Varguiniano.ScriptableCore.Editor.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for string variable.
    /// </summary>
    [CustomEditor(typeof(StringVariable))]
    public class StringVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private StringVariable variable;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            variable = (StringVariable) target;

            EditorGUI.BeginChangeCheck();
            {
                variable.Value = EditorGUILayout.TextField("Value", variable.Value);

                variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(variable);
        }
    }
}