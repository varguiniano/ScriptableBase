using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Primitives;

namespace Sample
{
    /// <inheritdoc />
    /// <summary>
    /// Class that takes the value of a bool variable and displays it on a text.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class ValueOfBoolToText : VariableValueChangeEventListener<bool>
    {
        /// <summary>
        /// Variable to take the value from.
        /// </summary>
        [SerializeField] private BoolVariable variable;

        /// <summary>
        /// Text to display the value into.
        /// </summary>
        private Text text;

        /// <summary>
        /// Fill references.
        /// </summary>
        private void Awake()
        {
            text = GetComponent<Text>();
            VariableToListen = variable;
        }

        /// <summary>
        /// Set the value once.
        /// </summary>
        private void Start() => OnValueChanged();

        /// <inheritdoc />
        /// <summary>
        /// Called when the value of the variable changes.
        /// </summary>
        protected override void OnValueChanged() => text.text = variable.Value.ToString();
    }
}