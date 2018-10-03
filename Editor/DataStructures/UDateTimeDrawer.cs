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
        /// <summary>
        /// The year value.
        /// </summary>
        private int year;

        /// <summary>
        /// The month value.
        /// </summary>
        private int month = 1;

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

                    SerializedString(position, property);

                    // Selectors(position, property); 

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
        [Obsolete("The selectors should be used instead.")]
        private void SerializedString(Rect position, SerializedProperty property)
        {
            var amountRect = new Rect(position.x, position.y, position.width, position.height);
            EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("dateTime"), GUIContent.none);
        }

        /// <summary>
        /// My own way, with selectors for each value.
        /// </summary>
        /// <param name="position">Drawer position.</param>
        /// <param name="property">Drawer property.</param>
        private void Selectors(Rect position, SerializedProperty property)
        {
            var dateTime = property.FindPropertyRelative("dateTime");

            var amountRect = new Rect(position.x, position.y, 50, position.height);
            year = EditorGUI.IntField(amountRect, year);
            year = Mathf.Clamp(year, 1000, 3000);

            amountRect = new Rect(position.x + amountRect.width, position.y, 50, position.height);
            month = EditorGUI.Popup(amountRect, month - 1, GetMonthOptions()) + 1;

            var newDateTime = new DateTime(year, month, 1);
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
    }
}