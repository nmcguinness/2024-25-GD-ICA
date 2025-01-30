using UnityEditor;

namespace GD
{
    /// <summary>
    /// Add toggle for lock/unlock inspector window using a key shortcut e.g. CTRL + Q
    /// </summary>
    /// <see cref="https://www.programmersought.com/article/71125964072/"/>
    public class ToggleInspectorLock
    {
        [MenuItem("Tools/DkIT/UI/Toggle Inspector lock #q")]  //% = CTRL, # = SHIFT, q = shortcut alphanumberic key
        public static void Toggle()
        {
            var inspectorType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");

            var isLocked = inspectorType.GetProperty("isLocked", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            var inspectorWindow = EditorWindow.GetWindow(inspectorType);

            var state = isLocked.GetGetMethod().Invoke(inspectorWindow, new object[] { });

            isLocked.GetSetMethod().Invoke(inspectorWindow, new object[] { !(bool)state });
        }
    }
}