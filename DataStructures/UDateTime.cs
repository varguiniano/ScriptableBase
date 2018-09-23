using System;
using System.Globalization;
using UnityEngine;

namespace Varguiniano.ScriptableCore.DataStructures
{
    /// <summary>
    /// Serializable Datetime object.
    /// Credits to https://gist.github.com/EntranceJew.
    /// </summary>
    [Serializable]
    public class UDateTime : ISerializationCallbackReceiver 
    {
        /// <summary>
        /// Equivalent Datetime object.
        /// </summary>
        [HideInInspector] public DateTime DateTime;

        /// <summary>
        /// String to use in parsing the datetime.
        /// </summary>
        [HideInInspector] [SerializeField] private string dateTime;

        /// <summary>
        /// Operator for parsing.
        /// </summary>
        /// <param name="udt">Unity datetime.</param>
        /// <returns>C# datetime.</returns>
        public static implicit operator DateTime(UDateTime udt) => udt.DateTime;

        /// <summary>
        /// Operator for parsing.
        /// </summary>
        /// <param name="dt">C# datetime.</param>
        /// <returns>Unity datetime.</returns>
        public static implicit operator UDateTime(DateTime dt) => new UDateTime {DateTime = dt};

        /// <inheritdoc />
        /// <summary>
        /// Called before serialization.
        /// </summary>
        public void OnBeforeSerialize() => dateTime = DateTime.ToString(CultureInfo.InvariantCulture);
        
        /// <inheritdoc />
        /// <summary>
        /// Called after deserialization.
        /// </summary>
        public void OnAfterDeserialize() => DateTime.TryParse(dateTime, out DateTime);
    }
}