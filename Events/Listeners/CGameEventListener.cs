using UnityEngine;
using UnityEngine.Events;

namespace Varguiniano.ScriptableCore.Events.Listeners
{
    /// <inheritdoc/>
    /// <summary>
    /// Behaviour that listens to a given Scriptable Object Event.
    /// </summary>
    public abstract class CGameEventListener : MonoBehaviour
    {
        /// <summary>
        /// Event to listen to.
        /// </summary>
        protected GameEvent GameEvent;
        
        /// <summary>
        /// Actions to perform when the event is raised.
        /// </summary>
        public UnityEvent Response = new UnityEvent();

        /// <summary>
        /// Registers to the event.
        /// </summary>
        public virtual void OnEnable() => GameEvent.RegisterListener(this);

        /// <summary>
        /// Unregisters from the event.
        /// </summary>
        public virtual void OnDisable() => GameEvent.UnregisterListener(this);
    }
}