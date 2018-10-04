using System;
using UnityEditor;
using UnityEngine;
using Varguiniano.ScriptableCore.DataStructures;

namespace Varguiniano.ScriptableCore.Editor.DataStructures
{
    /// <inheritdoc />
    /// <summary>
    /// Custom drawer for UDatetime.
    /// Credits to https://gist.github.com/EntranceJew.
    /// </summary>
    [CustomPropertyDrawer(typeof(UDateTime))]
    public class UDateTimeDrawer : PropertyDrawer
    {
        /// <inheritdoc />
        /// <summary>
        /// Paint UI.
        /// </summary>
        /// <param name="position">Drawer position.</param>
        /// <param name="property">Drawer property.</param>
        /// <param name="label">Drawer label.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            {
                EditorGUI.BeginChangeCheck();
                {
                    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

                    var indent = EditorGUI.indentLevel;
                    EditorGUI.indentLevel = 0;

                    SeparateFields(position, property);

                    EditorGUI.indentLevel = indent;
                }
                if (EditorGUI.EndChangeCheck())
                {
                    property.serializedObject.ApplyModifiedProperties();
                    property.serializedObject.Update();
                }
            }
            EditorGUI.EndProperty();
        }

        /// <summary>
        /// EntranceJew's way, a string that can be serialized as a date time.
        /// </summary>
        /// <param name="position">Drawer position.</param>
        /// <param name="property">Drawer property.</param>
        [Obsolete]
        private void SerializedString(Rect position, SerializedProperty property)
        {
            var amountRect = new Rect(position.x, position.y, position.width, position.height);
            EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("DateTimeString"), GUIContent.none);
        }

        /// <summary>
        /// My own way, with separate fields for each value.
        /// </summary>
        /// <param name="position">Drawer position.</param>
        /// <param name="property">Drawer property.</param>
        private void SeparateFields(Rect position, SerializedProperty property)
        {
            var dateTime = (UDateTime) fieldInfo.GetValue(property.serializedObject.targetObject);

            var amountRect = new Rect(position.x, position.y, 50, position.height);
            dateTime.Year = EditorGUI.IntField(amountRect, dateTime.Year);

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 10, position.height);
            EditorGUI.LabelField(amountRect, "/");

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 25, position.height);
            dateTime.Month = EditorGUI.IntField(amountRect, dateTime.Month);

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 10, position.height);
            EditorGUI.LabelField(amountRect, "/");

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 25, position.height);
            dateTime.Day = EditorGUI.IntField(amountRect, dateTime.Day);

            amountRect = new Rect(amountRect.position.x + amountRect.width + 10, position.y, 25, position.height);
            dateTime.Hour = EditorGUI.IntField(amountRect, dateTime.Hour);

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 10, position.height);
            EditorGUI.LabelField(amountRect, ":");

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 25, position.height);
            dateTime.Minute = EditorGUI.IntField(amountRect, dateTime.Minute);

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 10, position.height);
            EditorGUI.LabelField(amountRect, ":");

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 25, position.height);
            dateTime.Second = EditorGUI.IntField(amountRect, dateTime.Second);

            property.FindPropertyRelative("DateTimeString").stringValue = dateTime.DateTimeString;
        }

        /// <summary>
        /// My own way, with selectors for each value.
        /// </summary>
        /// <param name="position">Drawer position.</param>
        /// <param name="property">Drawer property.</param>
        private void Selectors(Rect position, SerializedProperty property)
        {
            var dateTime = (UDateTime) fieldInfo.GetValue(property.serializedObject.targetObject);

            var amountRect = new Rect(position.x, position.y, 35, position.height);
            dateTime.Year = EditorGUI.IntField(amountRect, dateTime.Year);

            amountRect = new Rect(position.x + amountRect.width, position.y, 73, position.height);
            dateTime.Month = EditorGUI.Popup(amountRect, dateTime.Month - 1, GetMonthOptions()) + 1;

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 33, position.height);
            dateTime.Day = EditorGUI.Popup(amountRect, dateTime.Day - 1,
                               GetNumberOptions(1, DateTime.DaysInMonth(dateTime.Year, dateTime.Month))) + 1;

            amountRect = new Rect(amountRect.position.x + amountRect.width + 10, position.y, 33, position.height);
            dateTime.Hour = EditorGUI.Popup(amountRect, dateTime.Hour, GetNumberOptions(0, 23));

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 33, position.height);
            dateTime.Minute = EditorGUI.Popup(amountRect, dateTime.Minute, GetNumberOptions(0, 59));

            amountRect = new Rect(amountRect.position.x + amountRect.width, position.y, 33, position.height);
            dateTime.Second = EditorGUI.Popup(amountRect, dateTime.Second, GetNumberOptions(0, 59));

            property.FindPropertyRelative("DateTimeString").stringValue = dateTime.DateTimeString;
        }

        /// <summary>
        /// Returns an array with the options for the months.
        /// </summary>
        /// <returns>The array with the options.</returns>
        private static string[] GetMonthOptions() =>
            new[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                "November", "December"
            };

        /// <summary>
        /// Creates a list of numbers to be used in popup options.
        /// </summary>
        /// <param name="start">The starting number.</param>
        /// <param name="end">The ending number.</param>
        /// <returns>A list of number in strings.</returns>
        private static string[] GetNumberOptions(int start, int end)
        {
            var list = new string[end - start + 1];
            for (var i = start; i <= end; i++) list[i - start] = i.ToString();
            return list;
        }
    }
}