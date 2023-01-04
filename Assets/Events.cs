using UnityEngine.SceneManagement;
using UnityEngine;
//Ernest was here
using System.Collections;

public class Events : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Controls;
    public GameObject Powerhouse;

    public void Replay()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        Controls.SetActive(true);
        Powerhouse.SetActive(true);
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Controls.SetActive(false);
        Powerhouse.SetActive(false);
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Character Select");
        Time.timeScale = 1;
        //Time.timeScale = 1;
        //StartCoroutine(GoBackCharSel());

    }

    //Ernest was Here
    IEnumerator GoBackCharSel()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Character Select");
    }

    //IEnumerator Restart()
    //{
    //    Time.timeScale = 1;
    //    yield return new WaitForSeconds(0.1f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

}
