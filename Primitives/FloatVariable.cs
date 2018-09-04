using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a float.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Float")]
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