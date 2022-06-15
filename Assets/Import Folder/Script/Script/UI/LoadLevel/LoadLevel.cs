using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private Slider loadLevelProgress;
    [SerializeField] private Slider loadLevelProgress2;
    private static int nextLevel=3;
    
    void Start()
    {
        StartCoroutine(StartLoadLevel());
    }
    public void StartMap()
    {
        
    }

    public IEnumerator StartLoadLevel()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextLevel);
        while (!asyncOperation.isDone)
        {
            loadLevelProgress.value = asyncOperation.progress;
            loadLevelProgress2.value = asyncOperation.progress;
            yield return null;
        }
    }

    public static void SetNextLevel(int nextLevel)
    {
        LoadLevel.nextLevel = nextLevel;
    }
}
