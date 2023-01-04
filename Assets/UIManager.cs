using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class UIManager : MonoBehaviour
{
    public GameObject TutPanel;
    public GameObject TutButton;
    public Text highscore;

    void Update()
    {
        highscore.text = "Highscore\n" + PlayerPrefs.GetInt("highscore", 0).ToString() + " " + "Meters!";
    }

    public void OpenTut()
    {
        TutPanel.SetActive(true);
        TutButton.SetActive(true);
    }
    public void CloseTut()
    {
        TutPanel.SetActive(false);
        TutButton.SetActive(false);
    }
}
