using UnityEditor;
using UnityEngine;
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
        private StringVariable Variable => (StringVariable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.Value = EditorGUILayout.TextField("Value", Variable.Value);

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}