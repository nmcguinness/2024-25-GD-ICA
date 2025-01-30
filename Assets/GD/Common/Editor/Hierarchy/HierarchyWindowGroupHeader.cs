using UnityEngine;
using UnityEditor;

namespace GD
{
    /// <summary>
    /// Hierarchy Window Group Header
    /// http://diegogiacomelli.com.br/unitytips-hierarchy-window-group-header
    /// </summary>
    /// <example>To create a folder make an empty with the name "*** folder name" in the hierarchy</example>
    [InitializeOnLoad]
    public static class HierarchyWindowGroupHeader
    {
        private static readonly Color folderFillColor = Color.blue;
        private static readonly string singleCharFolderDelimiter = "*";
        private static readonly string folderDelimiter = $"{singleCharFolderDelimiter}{singleCharFolderDelimiter}{singleCharFolderDelimiter}";

        static HierarchyWindowGroupHeader()

        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null && gameObject.name.StartsWith(folderDelimiter, System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, folderFillColor);
                EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace(singleCharFolderDelimiter, "").ToUpperInvariant());
            }
        }
    }
}