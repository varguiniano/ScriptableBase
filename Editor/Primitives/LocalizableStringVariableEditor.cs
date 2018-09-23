using UnityEditor;
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
        private LocalizableStringVariable variable;

        /// <inheritdoc />
        /// <summary>
        /// GUI display.
        /// </summary>
        public override void OnInspectorGUI()
        {
            variable = (LocalizableStringVariable) target;

            EditorGUI.BeginChangeCheck();
            {
                variable.LanguageManager = (LanguageManager) EditorGUILayout.ObjectField("Language manager",
                    variable.LanguageManager, typeof(LanguageManager), false);

                variable.Value = EditorGUILayout.TextField("Value", variable.Value);
                EditorGUI.BeginDisabledGroup(true);
                {
                    EditorGUILayout.TextField("Localized value", variable.LocalizedValue);
                }
                EditorGUI.EndDisabledGroup();

                variable.OnValueChanged = (GameEvent) EditorGUILayout.ObjectField("On value changed event",
                    variable.OnValueChanged, typeof(GameEvent), false);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(variable);
        }
    }
}