using UnityEngine;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Similar to variable, but this class can not be saved as a persistent json.
    /// </summary>
    /// <typeparam name="T">The type the variable will hold.</typeparam>
    public abstract class NonPersistentVariable<T> : ScriptableObject
    {
        /// <summary>
        /// The data to hold.
        /// </summary>
        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                if(OnValueChanged)
                    OnValueChanged.Raise();
            }
        }

        /// <summary>
        /// Backfield for Value.
        /// </summary>
        [SerializeField]
        private T value;

        /// <summary>
        /// Event to raise when the value of the variable is changed.
        /// </summary>
        public GameEvent OnValueChanged;
    }
}