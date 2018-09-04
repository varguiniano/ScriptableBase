using UnityEngine;
using Varguiniano.ScriptableCore.Events;

namespace Varguiniano.ScriptableCore.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Generic class that can hold any data as an scriptable object.
    /// Custom editors to access the value field will have to ve implemented for each variable type.
    /// </summary>
    /// <typeparam name="T">The type the variable will hold.</typeparam>
    public abstract class Variable<T> : ScriptableObject
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