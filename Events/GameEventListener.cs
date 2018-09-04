using UnityEngine;
using UnityEngine.Events;

namespace Varguiniano.ScriptableCore.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Game event listener that can be added as a component.
    /// </summary>
    public class GameEventListener : CGameEventListener
    {
        /// <summary>
        /// Event to listen to.
        /// </summary>
        [SerializeField] private GameEvent eventToListenTo;

        /// <summary>
        /// Response to give.
        /// </summary>
        [SerializeField] private UnityEvent responseToGive;

        /// <summary>
        /// Assign references.
        /// </summary>
        private void Awake()
        {
            GameEvent = eventToListenTo;
            Response = responseToGive;
        }
    }
}