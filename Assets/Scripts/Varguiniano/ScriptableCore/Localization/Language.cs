using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Varguiniano.ScriptableCore.Localization
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds the definition of a language.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Language")]
    public class Language : ScriptableObject
    {
        #region Variables

        /// <summary>
        /// Id of the language.
        /// </summary>
        public string LanguageId;

        /// <summary>
        /// Actual language definition.
        /// </summary>
        public List<IdWordPair> Words = new List<IdWordPair>();

        #endregion

        #region Access Functions

        /// <summary>
        /// Quick accessor for getting a word.
        /// </summary>
        /// <param name="id">The id for that word.</param>
        public string this[string id] => GetString(id);

        /// <summary>
        /// Returns the word for the given id;
        /// </summary>
        /// <param name="id">Id to look.</param>
        /// <returns>The word for that id.</returns>
        private string GetString(string id)
        {
            foreach (var pair in Words.Where(pair => pair.Id == id)) return pair.Word;
            return id;
        }

        /// <summary>
        /// Adds a new word to the language.
        /// </summary>
        /// <param name="id">Id for that word.</param>
        /// <param name="word">The word to add.</param>
        /// <param name="overwrite">If it already exists, should it be overwritten?</param>
        /// <returns>True if it was added.</returns>
        public bool AddWord(string id, string word, bool overwrite = true)
        {
            if (ContainsWord(id))
            {
                if(!overwrite) return false;
                RemoveWord(id);
            }
            
            Words.Add(new IdWordPair(id, word));
            return true;
        }

        /// <summary>
        /// Deletes a word given its id.
        /// </summary>
        /// <param name="id">The id to remove.</param>
        /// <returns>True if it was removed.</returns>
        public bool RemoveWord(string id)
        {
            foreach (var pair in Words)
            {
                if (pair.Id.Equals(id))
                {
                    Words.Remove(pair);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Allows the whole language to be retrieved as a clone.
        /// </summary>
        /// <returns>The whole language in a dictionary.</returns>
        public List<IdWordPair> GetAllWords()
        {
            var clone = new List<IdWordPair>();
            foreach (var pair in Words) clone.Add(new IdWordPair(pair.Id, pair.Word));
            return clone;
        }

        /// <summary>
        /// Clears the whole word list.
        /// </summary>
        public void Clear() => Words.Clear();

        #endregion

        #region Dictionary-like Functions

        /// <summary>
        /// Function to know if the language contains a word given its id.
        /// </summary>
        /// <param name="id">The id of the word.</param>
        /// <returns>True if the language contains that word.</returns>
        public bool ContainsWord(string id) => Words.Any(pair => pair.Id.Equals(id));

        /// <summary>
        /// Updates the language with the new given set of words.
        /// </summary>
        /// <param name="newLanguage">The new language.</param>
        public void UpdateLanguage(List<IdWordPair> newLanguage) => Words = newLanguage;

        #endregion
    }


    /// <summary>
    /// Class that imitates a string key value pair as Unity does not serialize dictionaries.
    /// </summary>
    [Serializable]
    public class IdWordPair
    {
        /// <summary>
        /// Id of the word.
        /// </summary>
        public string Id;
        
        /// <summary>
        /// Value of the word.
        /// </summary>
        public string Word;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Id of the word.</param>
        /// <param name="word">Value of the word.</param>
        public IdWordPair(string id, string word)
        {
            Id = id;
            Word = word;
        }
    }
}