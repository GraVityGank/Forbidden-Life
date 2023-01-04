using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GoldenPickaxe : MonoBehaviour
{
    public int GodSmack = 250;
    public float duration = 5f;
    public GameObject GPickaxe;

    void Start()
    {
        GPickaxe = GameObject.FindGameObjectWithTag("AxeGUI");
    }
    void Update()
    {
        GPickaxe = GameObject.FindGameObjectWithTag("AxeGUI");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
            StartCoroutine(Pickup2(other));
            FindObjectOfType<AudioManager>().Play("Godsmack");
            //GPickaxe.SetActive(true);
        }
        if (other.CompareTag("Player F"))
        {
            StartCoroutine(Pickup(other));
            StartCoroutine(Pickup2(other));
            FindObjectOfType<AudioManager>().Play("Godsmack");
            //GPickaxe.SetActive(true);
        }
        if (other.CompareTag("Player B"))
        {
            StartCoroutine(Pickup(other));
            StartCoroutine(Pickup2(other));
            FindObjectOfType<AudioManager>().Play("Godsmack");
            //GPickaxe.SetActive(true);
        }
    }
    IEnumerator Pickup(Collider2D Player)
    {
        PlayerAction stats = Player.GetComponent<PlayerAction>();
        Player.GetComponent<PlayerDig>();
        GPickaxe.GetComponent<Image>().enabled = true;

        if (stats.attackdamage < GodSmack)
        {
            stats.attackdamage += GodSmack;
        }
        yield return new WaitForSeconds(duration);
        stats.attackdamage = 100;
    }
    IEnumerator Pickup2(Collider2D Player)
    {
        PlayerDig stats = Player.GetComponent<PlayerDig>();
        GPickaxe.GetComponent<Image>().enabled = true;
        if (stats.digdamage < GodSmack)
        {
            stats.digdamage += GodSmack;
            Debug.Log("GODMODE!");
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        GPickaxe.GetComponent<Image>().enabled = false;
        stats.digdamage = 100;

        Destroy(gameObject);
        Debug.Log("GODMODE!");
    }
}
