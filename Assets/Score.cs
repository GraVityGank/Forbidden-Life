using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Player;
    public Text scoreText;
    //public hiscore Hiscore;  

    void Update()
    {
        scoreText.text = Mathf.Abs(Player.position.y).ToString("0" + "m");
        //scoreText.text = Mathf.RoundToInt(Mathf.Abs(Player.position.y)).ToString("0" + "m");
        //hiscore.ToggleEndMenu(score);
    }
}
