using UnityEngine;
using UnityEditor;
using UCL.Assets.Scripts.Attribute;

namespace UCL.Assets.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(RequiredAttribute))]
    public class IsNotNullAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var previousColor = GUI.color;
            var isNull = property.objectReferenceValue == null;
            if(isNull)
            {
                label.text = $"[Required]{label.text}";
                GUI.color = Color.red;
            }
            EditorGUI.PropertyField(position, property, label);
            GUI.color = previousColor;

            EditorGUI.EndProperty();
        }
    }
}
