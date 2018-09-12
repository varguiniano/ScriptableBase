using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.DataStructures;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Editor.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for Texture2D variable.
    /// </summary>
    [CustomEditor(typeof(Texture2DVariable))]
    public class Texture2DVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private Texture2DVariable Variable => (Texture2DVariable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.Value =
                    (Texture2D) EditorGUILayout.ObjectField("Value", Variable.Value, typeof(Texture2D), true);

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}