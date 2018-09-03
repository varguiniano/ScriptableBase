using UnityEngine;
using UnityEngine.Serialization;

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
        public int CurrentLanguageId;

        /// <summary>
        /// Public accessor for the current language id.
        /// </summary>
        public string CurrentLanguage =>
            languages.Length > 0 ? languages[CurrentLanguageId].LanguageId : "No languages";

        /// <summary>
        /// Returns an array of all the languages' names.
        /// </summary>
        public string[] AllLanguages
        {
            get
            {
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

        /// <summary>
        /// Changes to the given language.
        /// </summary>
        /// <param name="id">The language to change to.</param>
        /// <returns>True if the language was changed.</returns>
        public bool ChangeLanguage(string id)
        {
            for (var index = 0; index < languages.Length; index++)
            {
                var language = languages[index];
                if (language.LanguageId != id) continue;
                CurrentLanguageId = index;
                return true;
            }

            return false;
        }
    }
}