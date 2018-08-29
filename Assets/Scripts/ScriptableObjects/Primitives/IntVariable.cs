using System;
using ScriptableObjects.Core;
using UnityEngine;

namespace ScriptableObjects.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds an int.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/Int")]
    public class IntVariable : Variable<int>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the IntVariable.
    /// </summary>
    [Serializable]
    public class IntReference : Reference<int, IntVariable>
    {
    }
}