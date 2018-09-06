using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Varguiniano.ScriptableCore.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable Object that defines an event that can be raised and listened to.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// Listeners of the event.
        /// </summary>
        private readonly HashSet<UnityEvent> listeners = new HashSet<UnityEvent>();

        /// <summary>
        /// Registers a listener to the event.
        /// </summary>
        /// <param name="listener">The listener to register.</param>
        public void RegisterListener(CGameEventListener listener) => listeners.Add(listener.Response);
        
        /// <summary>
        /// Registers a listener to the event.
        /// </summary>
        /// <param name="listener">The listener to register.</param>
        public void RegisterListener(UnityEvent listener) => listeners.Add(listener);

        /// <summary>
        /// Unregisters an listener from the event.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void UnregisterListener(CGameEventListener listener)
        {
            if (listeners.Contains(listener.Response)) listeners.Remove(listener.Response);
        }
        
        /// <summary>
        /// Unregisters an listener from the event.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void UnregisterListener(UnityEvent listener)
        {
            if (listeners.Contains(listener)) listeners.Remove(listener);
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        public void Raise()
        {
            foreach (var response in listeners) response?.Invoke();
        }
    }
}