using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Events;
using Varguiniano.ScriptableCore.Persistence;

namespace Varguiniano.ScriptableCore.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Generic class that can hold any data as an scriptable object.
    /// Custom editors to access the value field will have to ve implemented for each variable type.
    /// </summary>
    /// <typeparam name="T">The type the variable will hold.</typeparam>
    public abstract class Variable<T> : PersistentScriptableObject
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
        
        /// <inheritdoc />
        /// <summary>
        /// Saves the value to json.
        /// </summary>
        /// <returns>The json.</returns>
        public override string ToPersistentJson() => JsonUtility.ToJson(new PersistentClass {Value = Value});

        /// <inheritdoc />
        /// <summary>
        /// Loads the value to json.
        /// </summary>
        /// <param name="json">The json to load.</param>
        public override void LoadFromPersistentJson(string json) => Value = JsonUtility.FromJson<PersistentClass>(json).Value;

        /// <summary>
        /// Class to be persisted in json.
        /// </summary>
        [Serializable]
        private class PersistentClass
        {
            /// <summary>
            /// The value of the variable.
            /// </summary>
            public T Value;
        }
    }
}