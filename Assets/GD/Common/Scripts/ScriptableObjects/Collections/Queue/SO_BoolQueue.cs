using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_BoolQueue", menuName = "GD/Types/Collections/Queue/Bool", order = 1)]
    public class SO_BoolQueue : SO_Queue<bool>
    {
    }
}