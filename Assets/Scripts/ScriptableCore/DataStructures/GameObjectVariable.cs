using System;
using ScriptableCore.Core;
using UnityEngine;

namespace ScriptableCore.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a GameObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Game Object")]
    public class GameObjectVariable : Variable<GameObject>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the GameObjectVariable.
    /// </summary>
    [Serializable]
    public class GameObjectReference : Reference<GameObject, GameObjectVariable>
    {
    }
}