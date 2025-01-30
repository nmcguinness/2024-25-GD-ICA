using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_StringList", menuName = "GD/Types/Collections/List/String", order = 4)]
    public class SO_StringList : SO_List<string>
    {
    }
}