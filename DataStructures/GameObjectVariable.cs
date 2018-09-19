using System;
using UnityEngine;
using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a GameObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Game Object")]
    public class GameObjectVariable : NonPersistentVariable<GameObject>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the GameObjectVariable.
    /// </summary>
    [Serializable]
    public class GameObjectReference : NonPersistentReference<GameObject, GameObjectVariable>
    {
    }
}