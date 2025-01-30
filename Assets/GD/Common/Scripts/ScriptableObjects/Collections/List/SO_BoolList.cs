using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_BoolList", menuName = "GD/Types/Collections/List/Bool", order = 1)]
    public class SO_BoolList : SO_List<bool>
    {
    }
}