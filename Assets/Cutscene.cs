using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject Skip;

    void Start()
    {
        StartCoroutine(GoToMenu());
    }
    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(33f);       
        SceneManager.LoadScene("Main Menu");
    }
    public void SkipScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
