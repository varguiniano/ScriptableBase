using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Localization;
using Varguiniano.ScriptableCore.Primitives;

namespace Varguiniano.ScriptableCore.Editor.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Custom editor for localizable string variable, allowing to see the localized string on edit time.
    /// </summary>
    [CustomEditor(typeof(LocalizableStringVariable))]
    public class LocalizableStringVariableEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to the variable being edited.
        /// </summary>
        private LocalizableStringVariable Variable => (LocalizableStringVariable) target;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                Variable.LanguageManager = (LanguageManager) EditorGUILayout.ObjectField("Language manager",
                    Variable.LanguageManager, typeof(LanguageManager), false);

                Variable.Value = EditorGUILayout.TextField("Value", Variable.Value);
                EditorGUI.BeginDisabledGroup(true);
                {
                    EditorGUILayout.TextField("Localized value", Variable.LocalizedValue);
                }
                EditorGUI.EndDisabledGroup();

                Variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    Variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(Variable);
        }
    }
}