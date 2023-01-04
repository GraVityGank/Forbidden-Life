using UnityEngine;
using UnityEngine.UI;

public class hiscore : MonoBehaviour
{
    public Transform Player;
    public Text scoreText;
    //public hiscore Hiscore;

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = (collectiblecount + Mathf.Abs(Player.position.y)).ToString("0");
        scoreText.text =  (Mathf.Abs(Player.position.y)).ToString("0");
        //hiscore.ToggleEndMenu(score);
    }
}

