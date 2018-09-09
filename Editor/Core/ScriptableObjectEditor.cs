using UnityEditor;

namespace Varguiniano.ScriptableCore.Editor.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Class with some extra functionality for editors for scriptable objects.
    /// </summary>
    public class ScriptableObjectEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="name">Name of that property.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected void PaintProperty(string name, bool includeChildren = false)
        {
            var property = serializedObject.FindProperty(name);
            EditorGUILayout.PropertyField(property, includeChildren);
        }

        /// <summary>
        /// Paints the property given.
        /// </summary>
        /// <param name="serializedObject">The serialized object to look into.</param>
        /// <param name="name">Name of that property.</param>
        /// <param name="includeChildren">Should it include children?</param>
        protected static void PaintProperty(SerializedObject serializedObject, string name,
            bool includeChildren = false)
        {
            var property = serializedObject.FindProperty(name);
            EditorGUILayout.PropertyField(property, includeChildren);
        }
    }
}