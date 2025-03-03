using GD.Events;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(GameEventCollectionGroup))]
public class GameEventChangeGroupEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        float buttonHeight = 20;
        Rect fieldRect = new Rect(position.x, position.y, position.width, position.height - buttonHeight);
        Rect buttonRect = new Rect(position.x, position.y + position.height - buttonHeight, position.width, buttonHeight);

        EditorGUIUtility.wideMode = true;
        EditorGUI.PropertyField(fieldRect, property, label, true);

        if (GUI.Button(buttonRect, "Generate Events"))
        {
            string definingClassName = GetDefiningClassName(property); ;
            string scriptableObjectPath = GetScriptableObjectPath(property);

            string folder = EditorUtility.SaveFolderPanel("Select Folder to Save Events", scriptableObjectPath, "");
            if (!string.IsNullOrEmpty(folder))
            {
                GenerateEvents(property, folder, definingClassName);
            }
        }

        EditorGUI.EndProperty();
    }

    private void GenerateEvents(SerializedProperty property, string folderPath, string className)
    {
        string relativePath = "Assets" + folderPath.Substring(Application.dataPath.Length);
        object changeEventsInstance = GetTargetObjectWithProperty(property);

        if (changeEventsInstance == null) return;

        FieldInfo[] eventFields = changeEventsInstance.GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.FieldType == typeof(GameEvent))
            .ToArray();

        foreach (var field in eventFields)
        {
            string eventName = $"{className} - {field.Name}"; // ✅ Name format: Blackboard - OnAdded
            GameEvent newEvent = CreateEventAsset(eventName, relativePath);

            // Assign the new event to the field in ChangeEvents
            field.SetValue(changeEventsInstance, newEvent);
        }

        property.serializedObject.ApplyModifiedProperties();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private GameEvent CreateEventAsset(string eventName, string folderPath)
    {
        GameEvent newEvent = ScriptableObject.CreateInstance<GameEvent>();
        string path = Path.Combine(folderPath, $"{eventName}.asset");
        AssetDatabase.CreateAsset(newEvent, path);
        return AssetDatabase.LoadAssetAtPath<GameEvent>(path);
    }

    private string GetDefiningClassName(SerializedProperty property)
    {
        object changeEventsInstance = GetTargetObjectWithProperty(property);
        if (changeEventsInstance == null) return "Unknown";

        FieldInfo fieldInfo = property.serializedObject.targetObject.GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.GetValue(property.serializedObject.targetObject) == changeEventsInstance);

        return fieldInfo != null ? property.serializedObject.targetObject.GetType().Name : "Unknown";
    }

    private string GetParentClassName(SerializedProperty property)
    {
        object targetObject = GetTargetObjectWithProperty(property);
        return targetObject?.GetType().Name ?? "Unknown"; // ✅ Returns "Blackboard" instead of "ChangeEvents"
    }

    private string GetScriptableObjectPath(SerializedProperty property)
    {
        ScriptableObject scriptableObject = property.serializedObject.targetObject as ScriptableObject;
        if (scriptableObject == null) return "Assets/";

        string assetPath = AssetDatabase.GetAssetPath(scriptableObject);
        return string.IsNullOrEmpty(assetPath) ? "Assets/" : Path.GetDirectoryName(assetPath);
    }

    private object GetTargetObjectWithProperty(SerializedProperty property)
    {
        string path = property.propertyPath.Replace(".Array.data[", "[");
        object obj = property.serializedObject.targetObject;
        string[] elements = path.Split('.');

        foreach (string element in elements)
        {
            if (element.Contains("["))
            {
                string elementName = element.Substring(0, element.IndexOf("["));
                int index = int.Parse(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                obj = GetValueAtIndex(obj, elementName, index);
            }
            else
            {
                obj = GetFieldValue(obj, element);
            }
        }

        return obj;
    }

    private object GetFieldValue(object source, string fieldName)
    {
        if (source == null) return null;
        FieldInfo field = source.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        return field?.GetValue(source);
    }

    private object GetValueAtIndex(object source, string fieldName, int index)
    {
        var enumerable = GetFieldValue(source, fieldName) as System.Collections.IEnumerable;
        if (enumerable == null) return null;

        int i = 0;
        foreach (var item in enumerable)
        {
            if (i == index)
                return item;
            i++;
        }

        return null;
    }
}