using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.Primitives
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