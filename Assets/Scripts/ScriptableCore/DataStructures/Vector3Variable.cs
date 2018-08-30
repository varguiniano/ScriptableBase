using System;
using ScriptableCore.Core;
using UnityEngine;

namespace ScriptableCore.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Scriptable object that holds a Vector3.
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Core/Vector3")]
    public class Vector3Variable : Variable<Vector3>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Reference to the Vector3Variable.
    /// </summary>
    [Serializable]
    public class Vector3Reference : Reference<Vector3, Vector3Variable>
    {
    }
}