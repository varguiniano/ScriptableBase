using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a Datetime..
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/DateTime")]
    public class UDateTimeVariable : Variable<UDateTime>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the datetime variable.
    /// </summary>
    [Serializable]
    public class UDateTimeReference : Reference<UDateTime, UDateTimeVariable>
    {
    }
}