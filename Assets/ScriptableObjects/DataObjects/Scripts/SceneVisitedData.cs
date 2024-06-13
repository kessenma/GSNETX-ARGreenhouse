using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Generic/SceneVisitedData", fileName = "SceneVisitedData")]
public class SceneVisitedData : ScriptableObject
{
    private Dictionary<int, bool> visited = new Dictionary<int, bool>();

    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            visited.Add(i, false);
        }
    }

    public bool GetVisited(int sceneIndex)
    {
        return visited[sceneIndex];
    }

    public void SetVisited(int sceneIndex)
    {
        visited[sceneIndex] = true;
    }

    public void Reset()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            visited[i] = false;
        }
    }
}
