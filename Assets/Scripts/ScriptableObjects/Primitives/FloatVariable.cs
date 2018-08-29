using System;
using ScriptableObjects.Core;
using UnityEngine;

namespace ScriptableObjects.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a float.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/Float")]
    public class FloatVariable : Variable<float>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the FloatVariable.
    /// </summary>
    [Serializable]
    public class FloatReference : Reference<float, FloatVariable>
    {
    }
}