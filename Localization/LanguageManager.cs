using UnityEngine;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Localization
{
    /// <inheritdoc />
    /// <summary>
    /// Class that handles languages and localization.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Language/Language Manager")]
    public class LanguageManager : ScriptableObject
    {
        /// <summary>
        /// Currently loaded language.
        /// </summary>
        public int CurrentLanguageId
        {
            get { return currentLanguageId; }
            set
            {
                currentLanguageId = value;
                if(OnLanguageChanged)
                    OnLanguageChanged.Raise();
            }
        }

        /// <summary>
        /// Backfield for CurrentLanguageId.
        /// </summary>
        private int currentLanguageId;

        /// <summary>
        /// Event raised when the language is changed.
        /// </summary>
        public GameEvent OnLanguageChanged;

        /// <summary>
        /// Public accessor for the current language id.
        /// </summary>
        public string CurrentLanguage =>
            languages != null && languages.Length > 0 ? languages[CurrentLanguageId].LanguageId : "No languages";

        /// <summary>
        /// Returns an array of all the languages' names.
        /// </summary>
        public string[] AllLanguages
        {
            get
            {
                if(languages == null) return new string[]{};
                var result = new string[languages.Length];
                for (var index = 0; index < languages.Length; index++) result[index] = languages[index].LanguageId;

                return result;
            }
        }

        /// <summary>
        /// All the languages in the app.
        /// </summary>
        [SerializeField] private Language[] languages;

        /// <summary>
        /// Returns the word for the given id in the current language.
        /// </summary>
        /// <param name="wordId"></param>
        public string this[string wordId] => languages[CurrentLanguageId][wordId];
    }
}