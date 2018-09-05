using UnityEditor;
using UnityEngine;
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
        private FloatVariable Variable => (FloatVariable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.Value = EditorGUILayout.FloatField("Value", Variable.Value);

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}