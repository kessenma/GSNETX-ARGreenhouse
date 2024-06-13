using UnityEngine;

[CreateAssetMenu(menuName = "Variables/StringVariable", fileName = "StringVariable")]
public class StringVariable : ScriptableObject
{
    [SerializeField]
    private string value = "";

    public string Value
    {
        get { return value; }
        set { this.value = value; }
    }
}
