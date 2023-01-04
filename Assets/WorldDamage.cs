using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldDamage : MonoBehaviour
{
    [HideInInspector]
    public bool isHpLow = false;
    [HideInInspector]
    public bool isGamePaused = false;

    public float maxHealth = 10f;
    public float lowHealth = 0;
    public float decreasePerSecond;
    public float CurrentHealth;

    public Rigidbody2D playerRB;

    public Animator animator;

    public GameObject Player;

    public GameObject GameOverPanel;
    public GameObject HBar;
    public GameObject SBar;
    public GameObject PBar;
    public GameObject PauseBar;
    public GameObject Controls;
    public GameObject GasMask;
    public GameObject Godsmack;
    public GameObject ScoreContainer;
    public GameObject PowerUps;
    public HealthBar healthBar;

    void Start()
    {
        CurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        GasMask.GetComponent<Image>().enabled = false;
        Godsmack.GetComponent<Image>().enabled = false;
        //GasMask.SetActive(false);
        //Godsmack.SetActive(false);
    }

    void Update()
    {
        if (!isHpLow)
        {
            CurrentHealth -= Time.deltaTime * decreasePerSecond / 60f;
            healthBar.SetHealth(CurrentHealth);

        }
        if (CurrentHealth <= lowHealth)
        {
            animator.SetTrigger("IsDead");
            CurrentHealth += Time.deltaTime;
            isHpLow = true;
            DisableMovement();
            DisablePlayerFriction();
  
            StartCoroutine(GameOver());
            //GameOverPanel.SetActive(true);
            HBar.SetActive(false);
            SBar.SetActive(false);
            PBar.SetActive(false);
            PauseBar.SetActive(false);
            Controls.SetActive(false);
            ScoreContainer.SetActive(false);
            PowerUps.SetActive(false);

        }
        if (isGamePaused == true)
        {
            RetryGame();
        }

    }

    void DisablePlayerFriction()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector3(0, 0, 0);

    }

    void DisableMovement()
    {
        Player.GetComponent<CharacterController2D>().enabled = false;
        Player.GetComponent<PlayerDig>().enabled = false;
        Player.GetComponent<PlayerControls>().enabled = false;
        Player.GetComponent<PlayerAction>().enabled = false;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.2f);
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    void RetryGame()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            Application.LoadLevel(0);
        }
    }
    //void OnTriggerEnter2D(Collider2D Ups)
    //{
    //    if (Ups.tag == "GMask")
    //    {
    //        Debug.Log("Gassed Up!");
    //        StartCoroutine(GasMaskDuration());
    //    }
    //    if (Ups.tag == "GPickaxe")
    //    {
    //        Debug.Log("GODMODE!");
    //        StartCoroutine(GPickAxeDuration());
    //    }
    //}
    //IEnumerator GasMaskDuration()
    //{     
    //   GasMask.SetActive(true);
    //   yield return new WaitForSeconds(5f);
    //   GasMask.SetActive(false);
    //}
    //IEnumerator GPickAxeDuration()
    //{
    //    Godsmack.SetActive(true);
    //    yield return new WaitForSeconds(5f);
    //    Godsmack.SetActive(false);   
    //}
}

