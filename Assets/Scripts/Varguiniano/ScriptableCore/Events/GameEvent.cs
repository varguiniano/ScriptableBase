using System.Collections.Generic;
using UnityEngine;

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
        private readonly HashSet<IGameEventListener> listeners = new HashSet<IGameEventListener>();

        /// <summary>
        /// Registers a listener to the event.
        /// </summary>
        /// <param name="listener">The listener to register.</param>
        public void RegisterListener(IGameEventListener listener) => listeners.Add(listener);

        /// <summary>
        /// Unregisters an listener from the event.
        /// </summary>
        /// <param name="listener">The listener to remove.</param>
        public void UnregisterListener(IGameEventListener listener)
        {
            if (listeners.Contains(listener)) listeners.Remove(listener);
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        public void Raise()
        {
            foreach (var listener in listeners) listener.EventRaised();
        }
    }
}