using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AR/Virtual Greenhouse Item", fileName = "VirtualGreenhouseItem")]
public class VirtualGreenhouseItem : ScriptableObject
{
    
    public GameObject immediatePrefab;
    public GameObject nearNotFoundPrefab;
    public GameObject nearFoundPrefab;
    public GameObject farNotFoundPrefab;
    public GameObject farFoundPrefab;
    public GameObject popUpPrefab;

    public GameEvent itemFound;
    public GameEvent itemInCategoryFound;

    // Virtual object category
    public CategoryNames categoryName;

    // Virtual object name
    public ObjectNames objectName;
}
