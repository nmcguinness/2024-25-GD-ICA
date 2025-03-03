using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A dictionary-like structure that Unity can serialize.
/// Stores key-value pairs as a list (`ResourceEntry`) and synchronizes with an internal dictionary.
/// </summary>
[Serializable]
public class SerializableDictionary : ISerializationCallbackReceiver
{
    /// <summary>
    /// Internal class to store key-value pairs in a list (required for Unity serialization).
    /// </summary>
    [Serializable]
    private class ResourceEntry
    {
        public string key;
        public string value;
    }

    [SerializeField] private List<ResourceEntry> entries = new List<ResourceEntry>(); // ✅ Stores dictionary data

    private Dictionary<string, object> dictionary = new Dictionary<string, object>();

    /// <summary>
    /// Synchronizes data before serialization (saves list from dictionary).
    /// </summary>
    public void OnBeforeSerialize()
    {
        entries.Clear();
        foreach (var kvp in dictionary)
        {
            entries.Add(new ResourceEntry { key = kvp.Key, value = kvp.Value?.ToString() ?? "null" });
        }
    }

    /// <summary>
    /// Synchronizes data after deserialization (restores dictionary from list).
    /// </summary>
    public void OnAfterDeserialize()
    {
        dictionary.Clear();
        foreach (var entry in entries)
        {
            dictionary[entry.key] = entry.value;
        }
    }

    /// <summary>
    /// Allows dictionary-style access (e.g., data["key"] = value).
    /// </summary>
    public object this[string key]
    {
        get => dictionary.ContainsKey(key) ? dictionary[key] : null;
        set => dictionary[key] = value;
    }

    public void Add(string key, object value) => dictionary[key] = value;

    public bool ContainsKey(string key) => dictionary.ContainsKey(key);

    public bool TryGetValue(string key, out object value) => dictionary.TryGetValue(key, out value);

    public bool Remove(string key) => dictionary.Remove(key);

    public void Clear() => dictionary.Clear();

    public int Count => dictionary.Count;

    public Dictionary<string, object> GetDictionary() => dictionary;
}