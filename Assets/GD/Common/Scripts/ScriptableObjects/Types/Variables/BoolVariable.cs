using UnityEngine;

namespace GD.Types
{
    /// <summary>
    /// Variables which supports both local and shared scriptableobject of type bool
    /// </summary>
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "GD/Types/Variables/Bool", order = 1)]
    public class BoolVariable : ScriptableDataType<bool>
    {
    }
}