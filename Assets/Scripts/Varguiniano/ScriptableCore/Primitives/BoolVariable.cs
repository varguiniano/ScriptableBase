using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a bool.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Bool")]
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