using System.Collections.Generic;
using UnityEngine;

namespace GD
{
    /// <summary>
    /// Adds serializable dictionary to Unity.
    /// Limitations:
    ///     - key value is always a string
    /// </summary>
    /// <example>
    ///
    /// private SerializableDictionary myAssetDictionary;
    ///
    /// </example>
    /// <see cref="https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html?_ga=2.181520997.310178322.1615191172-1586311830.1610367054"/>
    public class SerializableDictionary : MonoBehaviour, ISerializationCallbackReceiver
    {
        private Dictionary<string, Object> resources = new Dictionary<string, Object>();

        // Hide this, because it will not work correctly without the custom editor.
        [HideInInspector]
        [SerializeField]
        private List<ResourceEntry> entries = new List<ResourceEntry>();

        public Object this[string key]
        {
            get
            {
                return resources.ContainsKey(key) ? resources[key] : null;
            }
            set
            {
                resources[key] = value;
            }
        }

        public bool ContainsKey(string key)
        {
            return resources.ContainsKey(key) ? true : false;
        }

        // Dictionary -> List
        public void OnBeforeSerialize()
        {
            entries.Clear();
            // You can iterate a dictionary like this if you want.
            foreach (KeyValuePair<string, Object> kvp in resources)
            {
                entries.Add(new ResourceEntry(kvp.Key, kvp.Value));
            }
        }

        // List -> Dictionary
        public void OnAfterDeserialize()
        {
            resources.Clear();
            foreach (ResourceEntry entry in entries)
            {
                resources.Add(entry.key, entry.value);
            }
        }

        [System.Serializable]
        public class ResourceEntry
        {
            public string key;
            public Object value;

            public ResourceEntry()
            { }

            public ResourceEntry(string key, Object value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}