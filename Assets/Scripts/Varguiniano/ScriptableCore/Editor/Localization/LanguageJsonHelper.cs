using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Localization;

namespace Varguiniano.ScriptableCore.Editor.Localization
{
    /// <summary>
    /// Helper class to save and load languages to json.
    /// </summary>
    public static class LanguageJsonHelper
    {
        /// <summary>
        /// Json file path.
        /// </summary>
        private const string FilePath = "/Language/Json/";

        /// <summary>
        /// Json extention.
        /// </summary>
        private const string JsonExtention = ".json";

        /// <summary>
        /// Saves the given language to json.
        /// </summary>
        /// <param name="language">The language to save.</param>
        public static void SaveLanguageToJson(Language language)
        {
            using (var fs = new FileStream(GetPath(language), FileMode.Create))
            using (var sw = new StreamWriter(fs))
                sw.Write(JsonUtility.ToJson(language));

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Loads a language file and opens it for edition.
        /// </summary>
        /// <param name="language">The language to open.</param>
        public static void OpenFileForEdition(Language language) => System.Diagnostics.Process.Start(GetPath(language));

        /// <summary>
        /// Loads a language from a json and returns it.
        /// <param name="language">The current language, to be overwritten.</param>
        /// </summary>
        /// <returns>True if it was successfully overwritten.</returns>
        public static bool LoadFromJson(ref Language language)
        {
            var path = EditorUtility.OpenFilePanel("Select language json", Application.dataPath, "json");
            string jsonString;
            using (var fs = new FileStream(path, FileMode.Open))
            using (var sr = new StreamReader(fs))
                jsonString = sr.ReadToEnd();

            try
            {
                JsonUtility.FromJsonOverwrite(jsonString, language);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the path for the given Language.
        /// </summary>
        /// <param name="language">The given language.</param>
        /// <returns>The path for that language.</returns>
        private static string GetPath(Language language) =>
            Application.dataPath + FilePath + language.LanguageId + JsonExtention;
    }
}