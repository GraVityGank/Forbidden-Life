using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject countDown;
    public GameObject UI;

    void Start()
    {
        UI.SetActive(false);
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        //FindObjectOfType<AudioManager>().Play("Countdown");
        //FindObjectOfType<AudioManager>().Stop("BGM Theme");
        float pauseTime = Time.realtimeSinceStartup + 4f;
        while (Time.realtimeSinceStartup < pauseTime)
        yield return 0;

        countDown.gameObject.SetActive(false);
        UI.SetActive(true);

        Time.timeScale = 1;
        //FindObjectOfType<AudioManager>().Play("BGM Theme");
    }
}
