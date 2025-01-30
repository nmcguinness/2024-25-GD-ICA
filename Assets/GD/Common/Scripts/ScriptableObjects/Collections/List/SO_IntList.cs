using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeIntList", menuName = "GD/Types/Collections/List/Int", order = 2)]
    public class SO_IntList : SO_List<int>
    {
    }
}