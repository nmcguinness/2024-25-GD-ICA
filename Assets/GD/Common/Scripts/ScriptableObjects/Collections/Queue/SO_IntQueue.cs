using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_IntQueue", menuName = "GD/Types/Collections/Queue/Int", order = 2)]
    public class SO_IntQueue : QueueSO<int>
    {
    }
}