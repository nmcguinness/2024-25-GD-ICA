using UnityEngine;

namespace GD.Types
{
    /// <summary>
    /// Supports both local and shared scriptableobject of type GameObject
    /// </summary>
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "GD/Types/Variables/Game Object", order = 6)]
    public class GameObjectVariable : ScriptableDataType<GameObject>
    {
    }
}