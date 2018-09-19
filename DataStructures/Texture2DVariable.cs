using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a Texture2D.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Texture2D")]
    public class Texture2DVariable : NonPersistentVariable<Texture2D>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the Texture2DVariable.
    /// </summary>
    [Serializable]
    public class Texture2DReference : NonPersistentReference<Texture2D, Texture2DVariable>
    {
    }
}