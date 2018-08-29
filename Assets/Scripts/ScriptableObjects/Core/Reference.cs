﻿using System;
using ScriptableObjects.Core;
using UnityEngine;

namespace ScriptableObjects.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Class that will hold a reference to the variable to be used.
    /// The designer can choose to use de data from the scriptable object or from a constant, for easier testing.
    /// </summary>
    /// <typeparam name="T">The type of the data to store.</typeparam>
    /// <typeparam name="V">The type of the variable that will hold that data.</typeparam>
    [Serializable]
    public class Reference<T, V> : Reference where V : Variable<T>
    {
        /// <summary>
        /// Should use a constant or the object?
        /// Default is true so no null pointers are thrown if the designer forgets to assign a value.
        /// </summary>
        [SerializeField]
        private bool UseConstant = true;

        /// <summary>
        /// The constant to use instead of the scriptable.
        /// </summary>
        [SerializeField]
        private T ConstantValue;

        /// <summary>
        /// The variable that holds the data.
        /// </summary>
        [SerializeField]
        private V Variable;

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
    /// Non generic class to be inherited by the actual usefull class.
    /// This non generic class is necessary for the property drawer to work.
    /// </summary>
    [Serializable]
    public abstract class Reference
    {  
    }
}

