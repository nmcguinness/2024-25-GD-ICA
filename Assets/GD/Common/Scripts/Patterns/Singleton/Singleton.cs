using UnityEngine;

namespace GD
{
    //See the following video tutorials before using this class in your code
    //Singletons & Managers in Unity - https://www.youtube.com/watch?v=92NQVeFiDeY
    //Everything You Need to Know About Singletons in Unity - https://www.youtube.com/watch?v=mpM0C6quQjs
    //How To Access Variables From Another Script In Unity - https://www.youtube.com/watch?v=-kd68uKt4jk
    //See C# Generics - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/

    /// <summary>
    /// A generic singleton base class for Unity MonoBehaviour singletons (SelectionManager,
    /// InventoryManager, GameManager, etc.). Ensures only one instance of T exists at runtime.
    /// </summary>
    /// <typeparam name="T">The type of the concrete singleton class.</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// Public accessor for the singleton instance. If none is found in the scene,
        /// a new one will be created.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<T>();

                    // If still null, create a new GameObject and add T.
                    if (instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name);
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// When the MonoBehaviour awakens, if no instance is assigned, we become the singleton.
        /// Otherwise, if there's a different instance, we destroy ourselves.
        /// </summary>
        protected virtual void Awake()
        {
            // If we haven’t assigned an instance yet, claim ownership.
            if (instance == null)
            {
                instance = this as T;

                // Optionally, persist across scene loads if desired.
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                // Another instance is already the singleton, so destroy this one.
                Destroy(gameObject);
                return;
            }

            // Ensure the GameObject is at the root of the hierarchy.
            if (transform.parent != null)
            {
                transform.SetParent(null);
            }
        }

        /// <summary>
        /// If the singleton is destroyed, clear the static reference
        /// so a new one can be created in the future if needed.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}