using UnityEngine;
using UnityEngine.Events;

namespace ScriptableCore.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Behaviour that listens to a given Scriptable Object Event.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        /// <summary>
        /// Event to listen to.
        /// </summary>
        [SerializeField]
        private GameEvent gameEvent;
        
        /// <summary>
        /// Actions to perform when the event is raised.
        /// </summary>
        [SerializeField]
        private UnityEvent response;

        /// <summary>
        /// Called when the event is raised.
        /// </summary>
        public void EventRaised() => response.Invoke();

        /// <summary>
        /// Registers to the event.
        /// </summary>
        private void OnEnable() => gameEvent.RegisterListener(this);

        /// <summary>
        /// Unregisters from the event.
        /// </summary>
        private void OnDisable() => gameEvent.UnregisterListener(this);
    }
}