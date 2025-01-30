using UnityEngine;

namespace GD.Types
{
    /// <summary>
    /// Variables which supports both local and shared scriptableobject of type int.
    /// </summary>
    [CreateAssetMenu(fileName = "IntVariable", menuName = "GD/Types/Variables/Int", order = 2)]
    public class IntVariable : ScriptableDataType<int>
    {
        public void Add(int a)
        {
            Value += a;
        }

        public void Add(IntVariable a)
        {
            Add(a.Value);
        }
    }
}