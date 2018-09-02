using UnityEngine;

namespace Varguiniano.ScriptableCore.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Generic class that can hold any data as an scriptable object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Variable<T> : ScriptableObject
    {
        /// <summary>
        /// The data to hold.
        /// </summary>
        public T Value;
    }
}