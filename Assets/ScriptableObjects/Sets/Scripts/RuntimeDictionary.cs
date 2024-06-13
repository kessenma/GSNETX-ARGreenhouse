using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class RunTimeDictionary<TKey,TValue> : ScriptableObject
{
    public Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey, TValue>();
}

