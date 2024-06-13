using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class SerializableTuple<T1, T2> : Tuple<T1, T2> {
    [SerializeField]
    private T1 value1;
    [SerializeField]
    private T2 value2;
    public SerializableTuple(T1 item1, T2 item2): base(item1, item2) {
        value1 = item1;
        value2 = item2;
    }
    public new T1 Item1 { get => value1; }
    public new T2 Item2 { get => value2; }
}
[Serializable]
public class IntFloatTuple : SerializableTuple<int, float>
{
    public IntFloatTuple(int item1, float item2) : base(item1, item2){ }
}

[Serializable]
public class StringTuple : SerializableTuple<string, string>
{
    public StringTuple(string item1, string item2) : base(item1, item2){ }
}












