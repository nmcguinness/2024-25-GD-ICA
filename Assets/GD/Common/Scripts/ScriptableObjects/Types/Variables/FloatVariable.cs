using UnityEngine;

namespace GD.Types
{
    /// <summary>
    /// Variables which supports both local and shared scriptableobject of type float
    /// </summary>
    [CreateAssetMenu(fileName = "FloatVariable",
        menuName = "GD/Types/Variables/Float", order = 3)]
    public class FloatVariable : ScriptableDataType<float>
    {
        public void Add(float a)
        {
            Value += a;
        }

        public void Add(FloatVariable a)
        {
            Add(a.Value);
        }
    }
}