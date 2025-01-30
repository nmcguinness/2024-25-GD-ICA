using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_StringQueue", menuName = "GD/Types/Collections/Queue/String", order = 4)]
    public class SO_StringQueue : SO_Queue<string>
    {
    }
}