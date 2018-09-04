using UnityEngine;
using UnityEngine.UI;
using Varguiniano.ScriptableCore.Primitives;

namespace Sample
{
	/// <inheritdoc />
	/// <summary>
	/// Class that takes the value of a toggle and saves it to a bool variable.
	/// </summary>
	[RequireComponent(typeof(Toggle))]
	public class ToggleToBoolVariable : MonoBehaviour
	{
		/// <summary>
		/// Variable to saved the value to.
		/// </summary>
		[SerializeField] private BoolVariable variable;

		/// <summary>
		/// The toggle to take the value from.
		/// </summary>
		private Toggle toggle;

		/// <summary>
		/// Find the toggle and start listening.
		/// </summary>
		private void Awake()
		{
			toggle = GetComponent<Toggle>();
			toggle.onValueChanged.AddListener(OnValueChanged);
		}

		/// <summary>
		/// Stop listening.
		/// </summary>
		private void OnDestroy() => toggle.onValueChanged.RemoveListener(OnValueChanged);

		/// <summary>
		/// Called when the value of the toggle is changed.
		/// </summary>
		/// <param name="value">The new value.</param>
		private void OnValueChanged(bool value) => variable.Value = value;
	}
}
