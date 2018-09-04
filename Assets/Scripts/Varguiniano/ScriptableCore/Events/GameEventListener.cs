using UnityEngine;
using UnityEngine.Events;

namespace Varguiniano.ScriptableCore.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Behaviour that listens to a given Scriptable Object Event.
    /// </summary>
    public abstract class GameEventListener : MonoBehaviour
    {
        /// <summary>
        /// Event to listen to.
        /// </summary>
        protected GameEvent GameEvent;
        
        /// <summary>
        /// Actions to perform when the event is raised.
        /// </summary>
        protected UnityEvent Response = new UnityEvent();

        /// <summary>
        /// Called when the event is raised.
        /// </summary>
        public void EventRaised() => Response.Invoke();

        /// <summary>
        /// Registers to the event.
        /// </summary>
        protected virtual void OnEnable() => GameEvent.RegisterListener(this);

        /// <summary>
        /// Unregisters from the event.
        /// </summary>
        protected virtual void OnDisable() => GameEvent.UnregisterListener(this);
    }
}