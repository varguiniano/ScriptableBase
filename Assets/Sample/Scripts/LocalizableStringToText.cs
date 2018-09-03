using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Primitives;

namespace Sample
{
    /// <inheritdoc />
    /// <summary>
    /// Takes the value of a localized string and displays it on a text.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizableStringToText : MonoBehaviour
    {
        /// <summary>
        /// Variable to take the value from.
        /// </summary>
        [SerializeField] private LocalizableStringReference variable;
        
        /// <summary>
        /// Text to display on.
        /// </summary>
        private Text text;

        /// <summary>
        /// Get the text component.
        /// </summary>
        private void Awake() => text = GetComponent<Text>();

        /// <summary>
        /// Takes the value from the variable and displays it.
        /// </summary>
        private void Update() => text.text = variable.LocalizedValue;
    }
}