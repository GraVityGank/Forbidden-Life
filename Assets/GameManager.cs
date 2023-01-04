using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject DoroButton;
    public GameObject HokoButton;
    public GameObject BBButton;

    public GameObject Panel;
    public GameObject CloseButton;

    public GameObject DoroTuts;
    public GameObject HokoTuts;
    public GameObject BBTuts;
    public GameObject RTMButton;

    public GameObject Dname;
    public GameObject Hname;
    public GameObject BBname;

    public GameObject CreditButton;
    public GameObject ReturnButton;
    public GameObject AboutUs;

    public void DoroWorld()
    {
        //SceneManager.LoadScene("SampleScene");
    }
    public void HokoriWorld()
    {
        //SceneManager.LoadScene("SampleScene");
    }
    public void BlockboyWorld()
    {
        //SceneManager.LoadScene("SampleScene");
    }
    public void CharacterSelect()
    {
        //SceneManager.LoadScene("Character Select");
        StartCoroutine(CharacterSelection());
    }
    public void OpenDoro()
    {     
        Panel.SetActive(true);
        DoroTuts.SetActive(true);
        CloseButton.SetActive(true);

        DoroButton.SetActive(false);
        HokoButton.SetActive(false);
        BBButton.SetActive(false);
        RTMButton.SetActive(false);

        Dname.SetActive(false);
        Hname.SetActive(false);
        BBname.SetActive(false);
    }
    public void OpenHoko()
    {
        Panel.SetActive(true);
        HokoTuts.SetActive(true);
        CloseButton.SetActive(true);

        DoroButton.SetActive(false);
        HokoButton.SetActive(false);
        BBButton.SetActive(false);
        RTMButton.SetActive(false);

        Dname.SetActive(false);
        Hname.SetActive(false);
        BBname.SetActive(false);

    }
    public void OpenBB()
    {
        Panel.SetActive(true);
        BBTuts.SetActive(true);
        CloseButton.SetActive(true);

        DoroButton.SetActive(false);
        HokoButton.SetActive(false);
        BBButton.SetActive(false);
        RTMButton.SetActive(false);

        Dname.SetActive(false);
        Hname.SetActive(false);
        BBname.SetActive(false);
    }
    public void CloseTuts()
    {
        Panel.SetActive(false);
        DoroTuts.SetActive(false);
        HokoTuts.SetActive(false);
        BBTuts.SetActive(false);
        CloseButton.SetActive(false);

        DoroButton.SetActive(true);
        HokoButton.SetActive(true);
        BBButton.SetActive(true);
        RTMButton.SetActive(true);

        Dname.SetActive(true);
        Hname.SetActive(true);
        BBname.SetActive(true);
    }
    public void OpenUs()
    {
        AboutUs.SetActive(true);
        CreditButton.SetActive(false);
        ReturnButton.SetActive(true);
    }
    public void CloseUs()
    {
        AboutUs.SetActive(false);
        CreditButton.SetActive(true);
        ReturnButton.SetActive(false);
    }
    public void Lobby()
    {
        StartCoroutine(MainMenu());
    }
    public void Exit()
    {
        Application.Quit();
    }

    //Ernest Was Here
    IEnumerator CharacterSelection()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Character Select");
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Main Menu");
    }

}
