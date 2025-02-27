using GD.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    //Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
    [Serializable]
    public abstract class ScriptableList<T> : ScriptableGameObject, IEnumerable<T>
    {
        [SerializeField]
        protected List<T> list = new List<T>();

        /// <summary>
        /// Provides a read-only view of the list list.
        /// </summary>
        public IReadOnlyList<T> Items => list;

        /// <summary>
        /// Indexer to get or set list in the list using array-like syntax.
        /// Logs a warning if the index is out of range.
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (list == null || index < 0 || index >= list.Count)
                {
                    Debug.LogWarning($"{nameof(ScriptableList<T>)}: Index {index} is out of range.");
                    return default;
                }
                return list[index];
            }
            set
            {
                if (list == null)
                {
                    Debug.LogWarning($"{nameof(ScriptableList<T>)}: The list is null.");
                    return;
                }
                if (index < 0 || index >= list.Count)
                {
                    Debug.LogWarning($"{nameof(ScriptableList<T>)}: Index {index} is out of range.");
                }
                else
                {
                    list[index] = value;
                }
            }
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        public void Add(T item)
        {
            if (list == null)
                list = new List<T>();
            list.Add(item);
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        public bool Remove(T item)
        {
            if (list == null)
                return false;
            bool removed = list.Remove(item);
            return removed;
        }

        /// <summary>
        /// Removes all items that match the predicate from the list.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int RemoveAll(Predicate<T> predicate)
        {
            return list.RemoveAll(predicate);
        }

        /// <summary>
        /// Clears all list from the list.
        /// </summary>
        public void Clear()
        {
            list?.Clear();
        }

        public int Count()
        {
            return list.Count;
        }

        public int Count(Func<T, bool> predicate)
        {
            //using C#'s Language Integrated Query (Linq) library - https://dotnettutorials.net/course/linq/
            return list.Count(predicate); //remember we have an enumerator in RuntimeList which allows us to call this method
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public void Sort(IComparer<T> comparer)
        {
            list.Sort(comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }
}