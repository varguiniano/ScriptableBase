using System;
using UnityEngine;

namespace Varguiniano.ScriptableCore.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Similar to reference, but this one can't be saved as a persistent json.
    /// </summary>
    /// <typeparam name="T">The type of the data to store.</typeparam>
    /// <typeparam name="TV">The type of the variable that will hold that data.</typeparam>
    [Serializable]
    public class NonPersistentReference<T, TV> : NonPersistentReference where TV : NonPersistentVariable<T>
    {
        /// <summary>
        /// Should use a constant or the object?
        /// Default is true so no null pointers are thrown if the designer forgets to assign a value.
        /// </summary>
        [SerializeField]
        protected bool UseConstant = true;

        /// <summary>
        /// The constant to use instead of the scriptable.
        /// </summary>
        [SerializeField]
        protected T ConstantValue;

        /// <summary>
        /// The variable that holds the data.
        /// </summary>
        [SerializeField]
        public TV Variable;

        /// <summary>
        /// Property to ease access to the data.
        /// </summary>
        public T Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Value = value;
            }
        }
    }
    
    /// <summary>
    /// Non generic class to be inherited by the actual useful class.
    /// This non generic class is necessary for the property drawer to work.
    /// </summary>
    [Serializable]
    public abstract class NonPersistentReference
    {  
    }
}

