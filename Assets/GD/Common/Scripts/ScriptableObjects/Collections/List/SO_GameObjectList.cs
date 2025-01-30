using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_GameObjectList", menuName = "GD/Types/Collections/List/Game Object", order = 7)]
    public class SO_GameObjectList : SO_List<GameObject>
    {
    }
}