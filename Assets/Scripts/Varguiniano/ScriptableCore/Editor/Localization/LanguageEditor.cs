using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Localization;

namespace Varguiniano.ScriptableCore.Editor.Localization
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for Language.
    /// </summary>
    [CustomEditor(typeof(Language))]
    public class LanguageEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Language we are editing.
        /// </summary>
        private Language language;

        /// <summary>
        /// Flag to know if we are in json mode or normal edition mode.
        /// </summary>
        private bool inJsonMode;

        /// <summary>
        /// Field to store a new Id.
        /// </summary>
        private string newId;

        /// <summary>
        /// Field to store a new Word.
        /// </summary>
        private string newWord;

        /// <summary>
        /// List to be editable through UI without modifying the language until changes are saved.
        /// </summary>
        private List<IdWordPair> editableList;

        /// <summary>
        /// Flag to know if the json has been correctly loaded.
        /// </summary>
        private bool jsonOk = true;

        /// <summary>
        /// Current position of the scroll view.
        /// </summary>
        private Vector2 scrollPos;

        /// <inheritdoc />
        /// <summary>
        /// Allows the language to be edited from ui.
        /// </summary>
        public override void OnInspectorGUI()
        {
            language = (Language) target;

            if (editableList == null) GetEditableCopy();

            language.LanguageId = EditorGUILayout.TextField("Language ID", language.LanguageId);


            if (GUILayout.Button(inJsonMode ? "Back to inspector edition" : "Json operations"))
                inJsonMode = !inJsonMode;

            if (inJsonMode)
                JsonMode();
            else
                WordEditor();
        }

        /// <summary>
        /// Edition of the language via json.
        /// </summary>
        private void JsonMode()
        {
            EditorGUILayout.HelpBox(
                "Remember to load from json after editing the file and that loading from json will completely override the language.",
                MessageType.Warning);
            EditorGUILayout.HelpBox("Oh, and you'll probably need to autoindent the json to understand anything.",
                MessageType.Info);

            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Edit json")) LanguageJsonHelper.OpenFileForEdition(language);
                if (GUILayout.Button("Load from json"))
                    jsonOk = LanguageJsonHelper.LoadFromJson(ref language);
                EditorUtility.SetDirty(language);
            }
            GUILayout.EndHorizontal();
            if (!jsonOk)
                EditorGUILayout.HelpBox("The file you selected is not a language json file.", MessageType.Error);

            GetEditableCopy();
        }

        /// <summary>
        /// Displays the interface for editing the words in the language.
        /// </summary>
        private void WordEditor()
        {
            EditorGUILayout.HelpBox("The json file is automatically updated when editing in this interface.",
                MessageType.Info);

            GUILayout.Label("Words");

            var list = language.GetAllWords();
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUIStyle.none, "verticalScrollbar",
                GUILayout.Height(Screen.height * .65f));
            {
                EditorGUILayout.BeginVertical();
                {
                    var elementRemoved = false;
                    for (var index = 0; index < list.Count; index++)
                    {
                        var pair = list[index];
                        EditorGUILayout.BeginHorizontal();
                        {
                            editableList[index].Id = EditorGUILayout.TextField("", editableList[index].Id,
                                GUILayout.Width(Screen.width * .1f));
                            editableList[index].Word = EditorGUILayout.TextArea(editableList[index].Word,
                                GUILayout.Width(Screen.width * .6f));

                            EditorGUI.BeginDisabledGroup(string.IsNullOrWhiteSpace(editableList[index].Id) ||
                                                         string.IsNullOrWhiteSpace(editableList[index].Word) ||
                                                         pair.Id != editableList[index].Id &&
                                                         language.ContainsWord(editableList[index].Id) ||
                                                         pair.Id == editableList[index].Id &&
                                                         pair.Word == editableList[index].Word);
                            {
                                if (GUILayout.Button("Save", GUILayout.Width(Screen.width * .1f)))
                                {
                                    language.UpdateLanguage(editableList);
                                    LanguageJsonHelper.SaveLanguageToJson(language);
                                    GetEditableCopy();
                                    EditorUtility.SetDirty(language);
                                }
                            }
                            EditorGUI.EndDisabledGroup();

                            if (GUILayout.Button("Delete", GUILayout.Width(Screen.width * .1f)))
                            {
                                language.RemoveWord(pair.Id);
                                elementRemoved = true;
                                LanguageJsonHelper.SaveLanguageToJson(language);
                                EditorUtility.SetDirty(language);
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                        WordEditorErrorDisplay(editableList[index].Id, editableList[index].Word, pair.Id);
                    }

                    if (elementRemoved)
                    {
                        GetEditableCopy();
                        EditorUtility.SetDirty(language);
                    }
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndScrollView();

            EditorGUILayout.BeginHorizontal();
            {
                newId = EditorGUILayout.TextField("", newId, GUILayout.Width(Screen.width * .1f));
                newWord = EditorGUILayout.TextArea(newWord, GUILayout.Width(Screen.width * .6f));

                EditorGUI.BeginDisabledGroup(string.IsNullOrWhiteSpace(newId) || string.IsNullOrWhiteSpace(newWord) ||
                                             language.ContainsWord(newId));
                {
                    if (GUILayout.Button("Add", GUILayout.Width(Screen.width * .2f)))
                    {
                        language.AddWord(newId, newWord, false);
                        newId = "";
                        newWord = "";
                        GetEditableCopy();
                        LanguageJsonHelper.SaveLanguageToJson(language);
                        EditorUtility.SetDirty(language);
                    }
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();

            WordEditorErrorDisplay(newId, newWord);


            if (!GUILayout.Button("Clear all Words")) return;
            language.Clear();
            EditorUtility.SetDirty(language);
            GetEditableCopy();
        }

        /// <summary>
        /// Shows some errors based on user input.
        /// </summary>
        /// <param name="id">The id the user is trying to enter.</param>
        /// <param name="word">The word the user is trying to enter.</param>
        /// <param name="existingId">If this is the same id as the currently editing,
        /// we shouldn't display a warning.</param>
        private void WordEditorErrorDisplay(string id, string word, string existingId = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                EditorGUILayout.HelpBox("Id can't be empty", MessageType.Error);
            if (string.IsNullOrWhiteSpace(word)) EditorGUILayout.HelpBox("The word can't be empty", MessageType.Error);
            if (language.ContainsWord(id) && id != existingId)
                EditorGUILayout.HelpBox("This id already exists in the language", MessageType.Error);
        }

        /// <summary>
        /// Reloads the editable dictionary.
        /// </summary>
        private void GetEditableCopy() => editableList = language.GetAllWords();
    }
}