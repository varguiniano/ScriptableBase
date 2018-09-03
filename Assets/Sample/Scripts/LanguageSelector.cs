using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Localization;

namespace Sample
{
    /// <inheritdoc />
    /// <summary>
    /// Class that allows for the selection of a language from a dropdown menu.
    /// </summary>
    [RequireComponent(typeof(Dropdown))]
    public class LanguageSelector : MonoBehaviour
    {
        /// <summary>
        /// Reference to the language manager.
        /// </summary>
        [SerializeField] private LanguageManager languageManager;

        /// <summary>
        /// Reference to the dropdown.
        /// </summary>
        private Dropdown dropdown;

        /// <summary>
        /// Finds the dropdown and register for value change.
        /// </summary>
        private void Awake()
        {
            dropdown = GetComponent<Dropdown>();
            dropdown.options = languageManager.AllLanguages.Select(language => new Dropdown.OptionData(language))
                .ToList();
            dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        /// <summary>
        /// Unregister from value change. 
        /// </summary>
        private void OnDestroy() => dropdown.onValueChanged.RemoveListener(OnValueChanged);

        /// <summary>
        /// Called when the dropdown value is changed.
        /// </summary>
        /// <param name="value">The new value.</param>
        private void OnValueChanged(int value) => languageManager.CurrentLanguageId = value;
    }
}