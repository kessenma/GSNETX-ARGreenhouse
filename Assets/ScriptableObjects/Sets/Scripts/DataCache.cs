using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu]
public class DataCache : ScriptableObject
{
    #if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
    #endif
    
    public Dictionary<string, object> cache = new Dictionary<string, object>();

    public void Add(string key, object value)
    {
        try
        {
            // If cache encounters a key collision, Add the value to a list
            if (cache.ContainsKey(key))
            {
                if(cache[key] is IList<object>)
                {
                    ((IList<object>)cache[key]).Add(value);
                }
                else
                {
                    cache[key] = new List<object>() { cache[key], value };
                }
            }
            else
            {
                cache.Add(key, value);
            }
        }
        catch (ArgumentException e)
        {
            Debug.Log("Exception Encountered: " + e);
            // Handle Exception
        }
    }

    public object Get(string key)
    {
        if (cache.ContainsKey(key)) 
        {
            return cache[key];
        }
        return null;
    }

    public void Remove(string key, object value)
    {
        try
        {
            cache.Remove(key);
        }
        catch (ArgumentException)
        {
            // Handle Exception
        }
    }

}
