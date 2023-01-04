using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{

    public int randNum;
    public GameObject hints;
    public bool genHint = false;

    void Update()
    {
        if(genHint == false)
        {
            genHint = true;
            StartCoroutine(HintTracker());
        }
    }

    IEnumerator HintTracker()
    {
        randNum = Random.Range(1, 6);
        if (randNum == 1)
        {
            hints.GetComponent<TMPro.TextMeshProUGUI>().text = "Hint: Doro Means \"Dirt\" in Japanese";
        }
        else if (randNum == 2)
        {
            hints.GetComponent<TMPro.TextMeshProUGUI>().text = "Hint: There is a chance that a monster won't deal any damage to you";
        }
        else if (randNum == 3)
        {
            hints.GetComponent<TMPro.TextMeshProUGUI>().text = "Hint: Pills heal you a small amount of health upon pickup ";
        }
        else if (randNum == 4)
        {
            hints.GetComponent<TMPro.TextMeshProUGUI>().text = "Hint: The Necrosyte can insta-kill you";
        }
        else if (randNum == 5)
        {
            hints.GetComponent<TMPro.TextMeshProUGUI>().text = "Hint: Hokori Means \"Dust\" in Japanese";
        }
        else if (randNum == 6)
        {
            hints.GetComponent<TMPro.TextMeshProUGUI>().text = "Hint: Try dropping monsters with other monsters";
        }
        yield return new WaitForSeconds(3);
        genHint = false;
    }
}
