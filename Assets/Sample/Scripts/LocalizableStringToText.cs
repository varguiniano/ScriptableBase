using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Primitives;

namespace Sample
{
    /// <inheritdoc />
    /// <summary>
    /// Takes the value of a localized string and displays it on a text.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizableStringToText : CGameEventListener
    {
        /// <summary>
        /// Variable to take the value from.
        /// </summary>
        [SerializeField] private LocalizableStringReference variable;

        /// <summary>
        /// On language changed event.
        /// </summary>
        [SerializeField]
        private GameEvent onLanguageChangedEvent;
        
        /// <summary>
        /// Text to display on.
        /// </summary>
        private Text text;

        /// <summary>
        /// Fill references.
        /// </summary>
        private void Awake()
        {
            text = GetComponent<Text>();
            GameEvent = onLanguageChangedEvent;
            Response.AddListener(OnLanguageChanged);
        }

        /// <summary>
        /// Set the value once.
        /// </summary>
        private void Start() => OnLanguageChanged();

        /// <summary>
        /// Remove the listener.
        /// </summary>
        private void OnDestroy() => Response.RemoveListener(OnLanguageChanged);

        /// <summary>
        /// Takes the value from the variable and displays it.
        /// </summary>
        private void OnLanguageChanged() => text.text = variable.LocalizedValue;
    }
}