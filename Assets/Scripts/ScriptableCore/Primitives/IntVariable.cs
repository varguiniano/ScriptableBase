using System;
using ScriptableCore.Core;
using UnityEngine;

namespace ScriptableCore.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds an int.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Int")]
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