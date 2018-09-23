using UnityEngine;
using UnityEngine.UI;

namespace Varguiniano.ScriptableCore.Events.Raisers
{
    /// <inheritdoc />
    /// <summary>
    /// Behaviour that hooks to a button and calls the given event when that button is clicked.
    /// This can be also done by adding the vent to the OnClick event in the button inspector,
    /// but this class allows assigning the event on runtime.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class RaiseEventOnButtonClick : MonoBehaviour
    {
        /// <summary>
        /// The event to be called when the button is clicked.
        /// </summary>
        public GameEvent Event;

        /// <summary>
        /// The button to listen to.
        /// </summary>
        private Button button;

        /// <summary>
        /// Find the button and listen.
        /// </summary>
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(RaiseEvent);
        }

        /// <summary>
        /// Disconnect the listener.
        /// </summary>
        private void OnDestroy() => button.onClick.RemoveListener(RaiseEvent);

        /// <summary>
        /// Call the event.
        /// </summary>
        private void RaiseEvent()
        {
            if (Event != null)
                Event.Raise();
        }
    }
}