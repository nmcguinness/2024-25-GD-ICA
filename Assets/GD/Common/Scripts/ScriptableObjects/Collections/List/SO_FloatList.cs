using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_FloatList", menuName = "GD/Types/Collections/List/Float", order = 3)]
    public class SO_FloatList : SO_List<float>
    {
    }
}