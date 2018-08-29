using System;
using ScriptableObjects.Core;
using UnityEngine;

namespace ScriptableObjects.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a bool.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/Bool")]
    public class BoolVariable : Variable<float>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the BoolVariable.
    /// </summary>
    [Serializable]
    public class BoolReference : Reference<float, BoolVariable>
    {
    }
}