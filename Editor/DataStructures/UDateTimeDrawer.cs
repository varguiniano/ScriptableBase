using UnityEditor;
using UnityEngine;

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

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var amountRect = new Rect(position.x, position.y, position.width, position.height);

            EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("dateTime"), GUIContent.none);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}