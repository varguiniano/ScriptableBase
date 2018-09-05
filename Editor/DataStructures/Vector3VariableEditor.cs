using UnityEditor;
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
        private Vector3Variable Variable => (Vector3Variable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.Value = EditorGUILayout.Vector3Field("Value", Variable.Value);

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}