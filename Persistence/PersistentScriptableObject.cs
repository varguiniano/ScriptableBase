using UnityEngine;

namespace Varguiniano.ScriptableCore.Persistence
{
    /// <inheritdoc />
    /// <summary>
    /// Class that defines the functions an scriptable object should have to be persistent
    /// and therefore be 'saveable' by the PersistenceUtility.
    /// Classes inheriting this class must have an internal class with the data that want to make persistent.
    /// The functions this interface defines will take the data from that class and serialize it to json and viceversa.
    /// The data to be save must NEVER be references to other assets. This can't be serialized.
    /// The intention of this class is not to serialize an entire scriptable object,
    /// but only the values of that object that will change at runtime.
    /// </summary>
    public abstract class PersistentScriptableObject : ScriptableObject
    {
        /// <summary>
        /// Saves the data to a json string.
        /// </summary>
        /// <returns>The generated json string.</returns>
        public abstract string ToPersistentJson();

        /// <summary>
        /// Loads the data from a json string.
        /// </summary>
        /// <param name="json">The given json string.</param>
        public abstract void LoadFromPersistentJson(string json);
    }
}