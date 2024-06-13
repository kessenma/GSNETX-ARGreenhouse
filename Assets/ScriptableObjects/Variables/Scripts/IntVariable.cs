using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/IntVariable", fileName = "IntVariable")]
public class IntVariable : ScriptableObject
{
    [SerializeField]
    private int value;

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }
}
