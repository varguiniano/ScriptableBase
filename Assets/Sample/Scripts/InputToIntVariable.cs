using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Primitives;

namespace Sample
{
    /// <inheritdoc />
    /// <summary>
    /// Class that gets the int input from an input field and stores it on a variable.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class InputToIntVariable : MonoBehaviour
    {
        /// <summary>
        /// Variable to save the int to.
        /// </summary>
        [SerializeField] private IntReference variable;

        /// <summary>
        /// Input field to read.
        /// </summary>
        private InputField field;

        /// <summary>
        /// Get the input field and start listening.
        /// </summary>
        private void Awake()
        {
            field = GetComponent<InputField>();
            field.onValueChanged.AddListener(OnValueChanged);
        }

        /// <summary>
        /// Stop listening.
        /// </summary>
        private void OnDestroy() => field.onValueChanged.RemoveListener(OnValueChanged);

        /// <summary>
        /// Called when the value of the input field is changed.
        /// </summary>
        /// <param name="value">The new value.</param>
        private void OnValueChanged(string value) => variable.Value = int.Parse(value);
    }
}