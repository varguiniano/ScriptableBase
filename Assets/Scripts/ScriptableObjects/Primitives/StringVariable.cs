using System;
using ScriptableObjects.Core;
using UnityEngine;

namespace ScriptableObjects.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a string.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/String")]
    public class StringVariable : Variable<string>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the StringVariable.
    /// </summary>
    [Serializable]
    public class StringReference : Reference<string, StringVariable>
    {
    }
}