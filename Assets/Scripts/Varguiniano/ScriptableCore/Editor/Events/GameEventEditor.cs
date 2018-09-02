using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Editor.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for GameEvents.
    /// </summary>
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
        /// <inheritdoc />
        /// <summary>
        /// Allows the event to be raised from the ui.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = (GameEvent)target;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
} 