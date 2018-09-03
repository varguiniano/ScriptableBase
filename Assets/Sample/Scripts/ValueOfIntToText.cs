using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Primitives;

namespace Sample
{
    /// <inheritdoc />
    /// <summary>
    /// Takes the value of an scriptable int variable and displays it on a text element.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class ValueOfIntToText : MonoBehaviour
    {
        /// <summary>
        /// Variable to take the text from.
        /// </summary>
        [SerializeField] private IntReference variable;

        /// <summary>
        /// Text to display on.
        /// </summary>
        private Text text;

        /// <summary>
        /// Get the text component.
        /// </summary>
        private void Awake() => text = GetComponent<Text>();

        /// <summary>
        /// Takes the value from the variable and displays it.
        /// </summary>
        private void Update() => text.text = variable.Value.ToString();
    }
}