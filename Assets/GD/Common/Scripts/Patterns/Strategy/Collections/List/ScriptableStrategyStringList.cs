using UnityEngine;

/// <summary>
/// A ScriptableObject that holds a list of strings.
/// </summary>
namespace GD.Collections
{
    [CreateAssetMenu(fileName = "ScriptableStrategyStringList", menuName = "GD/Types/ScriptableList/Strategy/String")]
    public class ScriptableStrategyStringList : ScriptableStrategyList<string>
    {
    }
}