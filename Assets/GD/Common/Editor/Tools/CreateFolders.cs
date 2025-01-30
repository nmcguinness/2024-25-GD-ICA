using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GD
{
    /// <summary>
    /// Creates a consistent folder system under a user defined project name
    /// Access from "GD/Utils/Create Project Folders" in the main menu
    /// </summary>
    /// <see cref="https://unity.com/how-to/organizing-your-project"/>
    public class CreateFolders : EditorWindow
    {
        private static string projectName = "Type project name here...";
        private static int generateOption;
        private static readonly string[] generateOptions = { "Subfolders Only", "My Assets Only", "My Assets & Third Party Assets" };

        /// <summary>
        /// Displays the project folder creation popup window.
        /// </summary>
        [MenuItem("Tools/DkIT/Utils/Create project folders")]
        private static void ShowProjectPopup()
        {
            var window = GetWindow(typeof(CreateFolders));

            window.minSize = new Vector2(300, 140);
            window.maxSize = new Vector2(800, 140);

            var title = new GUIContent();
            title.text = "Create Project Folders";
            window.titleContent = title;
        }

        /// <summary>
        /// Creates all the necessary folders based on the user settings.
        /// </summary>
        private static void CreateAllFolders()
        {
            List<string> folders;

            if (generateOption == 0) // Subfolders Only
            {
                folders = new List<string>
                {
                    "Data",
                    "Meshes",
                    "Materials",
                    "Prefabs",
                    "Scripts",
                    "Shaders",
                    "Scenes/Start",
                    "Scenes/InProgress",
                    "Scenes/Completed",
                    "Settings",
                };
            }
            else
            {
                folders = new List<string>
                {
                    "Animations",
                    "Audio/Diegetic",
                    "Audio/Non Diegetic",
                    "Data",
                    "Editor",
                    "Materials",
                    "Meshes",
                    "Prefabs",
                    "Scripts",
                    "Scenes/Start",
                    "Scenes/InProgress",
                    "Scenes/Completed",
                    "Settings",
                    "Shaders",
                    "Textures"
                };
            }

            string baseFolderPath = $"Assets/{projectName}";

            // Create folders based on the selected option
            switch (generateOption)
            {
                case 0: // Subfolders Only
                    CreateFoldersInPath(baseFolderPath, folders);
                    break;

                case 1: // My Assets Only
                    CreateFoldersInPath($"{baseFolderPath}/My Assets", folders);
                    break;

                case 2: // My Assets & Third Party Assets
                    CreateFoldersInPath($"{baseFolderPath}/My Assets", folders);
                    CreateFoldersInPath($"{baseFolderPath}/Third Party Assets", folders);
                    break;
            }

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Success", $"Folders for {projectName} have been successfully created!", "OK");
        }

        /// <summary>
        /// Creates folders at the specified base path.
        /// </summary>
        /// <param name="basePath">The base path where folders will be created.</param>
        /// <param name="folders">The list of folders to create.</param>
        private static void CreateFoldersInPath(string basePath, List<string> folders)
        {
            foreach (string folder in folders)
            {
                string path = $"{basePath}/{folder}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        /// <summary>
        /// Initializes the window with default settings when it is enabled.
        /// </summary>
        private void OnEnable()
        {
            // Set the initial values
            generateOption = 0;
        }

        /// <summary>
        /// Draws the GUI elements for the window.
        /// </summary>
        private void OnGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox("Enter a project name and choose the folder generation option.", MessageType.Info);

            // Begin a horizontal layout group for Project Name
            GUILayout.BeginHorizontal();
            GUILayout.Label("Project Name");
            GUILayout.FlexibleSpace();
            if (projectName == "Type project name here...") projectName = string.Empty;
            projectName = EditorGUILayout.TextField(projectName);
            GUILayout.EndHorizontal();

            // Dropdown for Generate Options
            GUILayout.BeginHorizontal();
            GUILayout.Label("Generate");
            generateOption = EditorGUILayout.Popup(generateOption, generateOptions);
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Create Folders"))
                DoCreateAllFolders();
        }

        /// <summary>
        /// Validates and initiates the folder creation process.
        /// </summary>
        private void DoCreateAllFolders()
        {
            if (Directory.Exists($"Assets/{projectName}"))
            {
                // Show an error dialog if the project name already exists
                EditorUtility.DisplayDialog("Error", $"Assets/{projectName} already exists!", "OK");
            }
            else
            {
                CreateAllFolders();
            }
        }
    }
}