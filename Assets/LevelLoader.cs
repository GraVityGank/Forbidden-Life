using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider loadbar;
    public GameObject Infobuttons;

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        //yield return new WaitForSeconds(0.2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        Infobuttons.SetActive(false);
        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            loadbar.value = operation.progress;
            //yield return new WaitForSeconds(0.5f);
            yield return null;
        } 
    }
}
