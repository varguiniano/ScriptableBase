using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;
using Varguiniano.ScriptableCore.Localization;

namespace Varguiniano.ScriptableCore.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Localizable string scriptable variable.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Localizable String")]
    public class LocalizableStringVariable : NonPersistentVariable<string>
    {
        /// <summary>
        /// Reference to the language manager scriptable object.
        /// </summary>
        public LanguageManager LanguageManager;

        /// <summary>
        /// Returns the localized value of the string if able.
        /// </summary>
        public string LocalizedValue => LanguageManager ? LanguageManager[Value] : Value;
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the StringVariable.
    /// </summary>
    [Serializable]
    public class LocalizableStringReference : NonPersistentReference<string, LocalizableStringVariable>
    {
        /// <summary>
        /// Returns the localized value of the string if able.
        /// </summary>
        public string LocalizedValue =>
            UseConstant
                ? Variable && Variable.LanguageManager ? Variable.LanguageManager[ConstantValue] : ConstantValue
                : Variable.LocalizedValue;
    }
}