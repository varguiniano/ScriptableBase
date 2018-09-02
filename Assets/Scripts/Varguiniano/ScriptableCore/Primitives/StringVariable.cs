using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.Primitives
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a string.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/String")]
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