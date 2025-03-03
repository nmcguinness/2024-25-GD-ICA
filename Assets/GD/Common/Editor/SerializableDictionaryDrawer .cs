using GD.FSM;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SerializableDictionary))]
public class SerializableDictionaryDrawer : PropertyDrawer
{
    private bool foldout = true; // Controls visibility of the dictionary summary

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty entries = property.FindPropertyRelative("entries");

        // Foldout to show/hide dictionary summary
        foldout = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                                    foldout, label, true);

        if (!foldout)
        {
            EditorGUI.EndProperty();
            return;
        }

        EditorGUI.indentLevel++;
        position.y += EditorGUIUtility.singleLineHeight;

        // Display a summary of the dictionary contents
        for (int i = 0; i < entries.arraySize; i++)
        {
            SerializedProperty entry = entries.GetArrayElementAtIndex(i);
            SerializedProperty keyProp = entry.FindPropertyRelative("key");
            SerializedProperty valueProp = entry.FindPropertyRelative("value");

            string keyName = keyProp.stringValue;
            string valueType = "Unknown";
            string valueCount = "-";

            object actualValue = GetActualValue(property, keyName);
            if (actualValue != null)
            {
                valueType = actualValue.GetType().ToString();

                // Check if value is a list and display count
                if (actualValue is IList list)
                {
                    valueType = $"List<{GetListElementType(actualValue)}>";
                    valueCount = list.Count.ToString();
                }
            }

            // Readonly summary display
            EditorGUI.LabelField(position, $"{keyName} : {valueType} : {valueCount}");

            position.y += EditorGUIUtility.singleLineHeight;
        }

        EditorGUI.indentLevel--;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!foldout) return EditorGUIUtility.singleLineHeight;
        SerializedProperty entries = property.FindPropertyRelative("entries");
        return EditorGUIUtility.singleLineHeight * (entries.arraySize + 2);
    }

    /// <summary>
    /// Retrieves the actual runtime value from the dictionary.
    /// </summary>
    private object GetActualValue(SerializedProperty property, string key)
    {
        if (!(property.serializedObject.targetObject is Blackboard blackboard)) return null;
        if (blackboard.HasValue(key))
        {
            return blackboard.GetValue<object>(key);
        }
        return null;
    }

    /// <summary>
    /// Retrieves the element type of a list.
    /// </summary>
    private string GetListElementType(object listObj)
    {
        Type listType = listObj.GetType();
        if (listType.IsGenericType)
        {
            return listType.GetGenericArguments()[0].Name;
        }
        return "Unknown";
    }
}