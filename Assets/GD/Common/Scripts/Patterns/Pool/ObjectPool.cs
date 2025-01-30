using System.Collections.Generic;
using UnityEngine;

namespace GD.Pool
{
    /// <summary>
    /// A generic object pool for Unity components.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : Component
    {
        private Queue<T> pool;
        private T prefab;
        private Transform parentTransform;

        /// <summary>
        /// Initializes the Object Pool.
        /// </summary>
        /// <param name="prefab">The prefab of the object to pool.</param>
        /// <param name="initialSize">Initial number of objects in the pool.</param>
        /// <param name="parent">Optional parent transform to organize pooled objects.</param>
        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            this.prefab = prefab;
            parentTransform = parent;
            pool = new Queue<T>();

            for (int i = 0; i < initialSize; i++)
            {
                CreateNewObject();
            }
        }

        /// <summary>
        /// Retrieves an object from the pool.
        /// </summary>
        /// <returns>A pooled object of type T.</returns>
        public T Get()
        {
            if (pool.Count == 0)
            {
                CreateNewObject();
            }

            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Returns an object back to the pool.
        /// </summary>
        /// <param name="obj">The object to return.</param>
        public void ReturnToPool(T obj)
        {
            // TODO - Reset the object?

            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }

        /// <summary>
        /// Creates a new object and adds it to the pool.
        /// </summary>
        private void CreateNewObject()
        {
            T newObject = Object.Instantiate(prefab, parentTransform);
            newObject.gameObject.SetActive(false);
            pool.Enqueue(newObject);
        }
    }
}