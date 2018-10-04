using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;

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
        /// TODO: Remove the formerly serialized attribute in a later version when all the objects have (probably) been reserialized.
        /// </summary>
        [FormerlySerializedAs("dateTime")] [HideInInspector]
        public string DateTimeString;

        /// <summary>
        /// Constructor to today.
        /// </summary>
        public UDateTime()
        {
            DateTime = DateTime.Now;
        }

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
        public void OnBeforeSerialize() => DateTimeString = DateTime.ToString(CultureInfo.InvariantCulture);

        /// <inheritdoc />
        /// <summary>
        /// Called after deserialization.
        /// </summary>
        public void OnAfterDeserialize() => DateTime.TryParse(DateTimeString, out DateTime);

        #region Individual Accessors

        /// <summary>
        /// Year of the date.
        /// </summary>
        public int Year
        {
            get { return DateTime.Year; }
            set
            {
                var newYear = Mathf.Clamp(value, DateTime.MinValue.Year, DateTime.MaxValue.Year);
                var newDay = Mathf.Clamp(DateTime.Day, 1, DateTime.DaysInMonth(newYear, DateTime.Month));
                DateTime = new DateTime(newYear, DateTime.Month, newDay, DateTime.Hour, DateTime.Minute,
                    DateTime.Second, DateTime.Millisecond, DateTime.Kind);
            }
        }

        /// <summary>
        /// Month of the date.
        /// </summary>
        public int Month
        {
            get { return DateTime.Month; }
            set
            {
                var newMonth = Mathf.Clamp(value, 1, 12);
                var newDay = Mathf.Clamp(DateTime.Day, 1, DateTime.DaysInMonth(DateTime.Year, newMonth));
                DateTime = new DateTime(DateTime.Year, newMonth, newDay, DateTime.Hour, DateTime.Minute,
                    DateTime.Second, DateTime.Millisecond, DateTime.Kind);
            }
        }

        /// <summary>
        /// Day of the date.
        /// </summary>
        public int Day
        {
            get { return DateTime.Day; }
            set
            {
                var maxValue = DateTime.DaysInMonth(DateTime.Year, DateTime.Month);
                var newDay = Mathf.Clamp(value, 1, maxValue);
                DateTime = new DateTime(DateTime.Year, DateTime.Month, newDay, DateTime.Hour, DateTime.Minute,
                    DateTime.Second, DateTime.Millisecond, DateTime.Kind);
            }
        }

        /// <summary>
        /// Hour of the date.
        /// </summary>
        public int Hour
        {
            get { return DateTime.Hour; }
            set
            {
                var newHour = Mathf.Clamp(value, 0, 23);
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, newHour, DateTime.Minute,
                    DateTime.Second, DateTime.Millisecond, DateTime.Kind);
            }
        }

        /// <summary>
        /// Minute of the date.
        /// </summary>
        public int Minute
        {
            get { return DateTime.Minute; }
            set
            {
                var newMinute = Mathf.Clamp(value, 0, 59);
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, DateTime.Hour, newMinute,
                    DateTime.Second, DateTime.Millisecond, DateTime.Kind);
            }
        }

        /// <summary>
        /// Second of the date.
        /// </summary>
        public int Second
        {
            get { return DateTime.Second; }
            set
            {
                var newSecond = Mathf.Clamp(value, 0, 59);
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, DateTime.Hour, DateTime.Minute,
                    newSecond, DateTime.Millisecond, DateTime.Kind);
            }
        }

        #endregion
    }
}