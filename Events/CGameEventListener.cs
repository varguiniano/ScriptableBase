using UnityEngine;
using UnityEngine.Events;

namespace Varguiniano.ScriptableCore.Events
{
    /// <inheritdoc cref="IGameEventListener" />
    /// <summary>
    /// Behaviour that listens to a given Scriptable Object Event.
    /// </summary>
    public abstract class CGameEventListener : MonoBehaviour, IGameEventListener
    {
        /// <summary>
        /// Event to listen to.
        /// </summary>
        protected GameEvent GameEvent;
        
        /// <summary>
        /// Actions to perform when the event is raised.
        /// </summary>
        protected UnityEvent Response = new UnityEvent();

        /// <inheritdoc />
        /// <summary>
        /// Called when the event is raised.
        /// </summary>
        public void EventRaised() => Response?.Invoke();

        /// <inheritdoc />
        /// <summary>
        /// Registers to the event.
        /// </summary>
        public virtual void OnEnable() => GameEvent.RegisterListener(this);

        /// <inheritdoc />
        /// <summary>
        /// Unregisters from the event.
        /// </summary>
        public virtual void OnDisable() => GameEvent.UnregisterListener(this);
    }
}