// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;


public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public int CurrentIndex = 0;

    // create methods to handle and update index

}
