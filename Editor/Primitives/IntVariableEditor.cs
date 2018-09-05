using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Primitives;

namespace Varguiniano.ScriptableCore.Editor.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for int variable.
    /// </summary>
    [CustomEditor(typeof(IntVariable))]
    public class IntVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private IntVariable Variable => (IntVariable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.Value = EditorGUILayout.IntField("Value", Variable.Value);

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}