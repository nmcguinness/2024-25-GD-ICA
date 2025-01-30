using GD.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD
{
    //Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
    [System.Serializable]
    public abstract class SO_Queue<T> : ScriptableGameObject, IEnumerable<T>
    {
        [Header("Queue Contents")]
        private Queue<T> queue = new Queue<T>();

        public void Enqueue(T obj)
        {
            queue.Enqueue(obj);
        }

        public T Dequeue()
        {
            return queue.Dequeue();
        }

        public T Peek()
        {
            return queue.Peek();
        }

        public void Clear()
        {
            queue.Clear();
        }

        public int Count()
        {
            return queue.Count;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)queue).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)queue).GetEnumerator();
        }
    }
}