using UnityEngine;

namespace GD.Types
{
    /// <summary>
    /// Variables which supports both local and shared scriptableobject of type string.
    /// </summary>
    [CreateAssetMenu(fileName = "StringVariable", menuName = "GD/Types/Variables/String", order = 4)]
    public class StringVariable : ScriptableDataType<string>
    {
        public void Add(string a)
        {
            Value += a;
        }

        public void Add(StringVariable a)
        {
            Add(a.Value);
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(Value);
        }
    }
}