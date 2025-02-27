using UnityEngine;

/// <summary>
/// A ScriptableObject that holds a list of floats.
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SO_FloatList", menuName = "GD/Types/Collections/List/Float", order = 3)]
    public class FloatListSO : ListSO<float>
    {
    }
}