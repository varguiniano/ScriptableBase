using ScriptableCore.Core;
using UnityEditor;
using UnityEngine;

namespace ScriptableCore.Editor.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Custom drawer for the Reference inspector.
    /// This will show the reference in one line, allowing to choose between variable and object.
    /// </summary>
    [CustomPropertyDrawer(typeof(Reference), true)]
    public class ReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOption = {"Use Constant", "Use Variable"};

        /// <summary>
        /// Cached style to use to draw the popup button.
        /// </summary>
        private GUIStyle popupStyle;

        /// <inheritdoc />
        /// <summary>
        /// On GUI function that paints the drawer.
        /// </summary>
        /// <param name="position">Drawer position.</param>
        /// <param name="property">Drawer property.</param>
        /// <param name="label">Drawer label.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions")) {imagePosition = ImagePosition.ImageOnly};

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();
            
            var useConstant = property.FindPropertyRelative("UseConstant");
            var constantValue = property.FindPropertyRelative("ConstantValue");
            var variable = property.FindPropertyRelative("Variable");

            var buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            var result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOption, popupStyle);
            useConstant.boolValue = result == 0;
            EditorGUI.PropertyField(position, useConstant.boolValue ? constantValue : variable, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}