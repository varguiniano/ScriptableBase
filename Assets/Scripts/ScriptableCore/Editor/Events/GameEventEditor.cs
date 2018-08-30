using ScriptableCore.Events;
using UnityEditor;
using UnityEngine;

namespace ScriptableCore.Editor.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
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