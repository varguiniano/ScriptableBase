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
        private GameObjectVariable variable;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            variable = (GameObjectVariable) target;

            variable.Value =
                (GameObject) EditorGUILayout.ObjectField("Value", variable.Value, typeof(GameObject), true);

            variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                variable.OnValueChanged, typeof(GameEvent), false);
        }
    }
}