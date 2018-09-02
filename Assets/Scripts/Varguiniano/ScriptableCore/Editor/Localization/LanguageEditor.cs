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
                if(GUILayout.Button("Edit json")) LanguageJsonHelper.OpenFileForEdition(language);
                if (GUILayout.Button("Load from json")) LanguageJsonHelper.LoadFromJson(ref language);
            }
            GUILayout.EndHorizontal();
            GetEditableCopy();
        }

        /// <summary>
        /// Displays the interface for editing the words in the language.
        /// </summary>
        private void WordEditor()
        {
            GUILayout.Label("Words");

            var list = language.GetAllWords();
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUIStyle.none, "verticalScrollbar",
                GUILayout.Height(700));
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
                                GUILayout.Width(Screen.width * .2f));
                            editableList[index].Word = EditorGUILayout.TextArea(editableList[index].Word,
                                GUILayout.Width(Screen.width * .6f));

                            if (!string.IsNullOrWhiteSpace(editableList[index].Id) &&
                                !string.IsNullOrWhiteSpace(editableList[index].Word) &&
                                (editableList[index].Id != pair.Id && !language.ContainsWord(editableList[index].Id) ||
                                 editableList[index].Word != pair.Word))
                            {
                                language.UpdateLanguage(editableList);
                                LanguageJsonHelper.SaveLanguageToJson(language);
                            }

                            if (GUILayout.Button("Delete", GUILayout.Width(Screen.width * .2f)))
                            {
                                language.RemoveWord(pair.Id);
                                elementRemoved = true;
                                LanguageJsonHelper.SaveLanguageToJson(language);
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                    }

                    if (elementRemoved) GetEditableCopy();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndScrollView();

            EditorGUILayout.BeginHorizontal();
            {
                newId = EditorGUILayout.TextField("", newId, GUILayout.Width(Screen.width * .2f));
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
                    }
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Clear all Words"))
                language.Clear();
        }

        /// <summary>
        /// Reloads the editable dictionary.
        /// </summary>
        private void GetEditableCopy() => editableList = language.GetAllWords();
    }
}