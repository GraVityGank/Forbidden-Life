using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public float HealthBoost = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            FindObjectOfType<AudioManager>().Play("Pickup");
            PlayerManager.collectiblevalue++;
            PlayerManager.collectiblecount++;
            PlayerManager.collectiblecount += 9;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player F"))
        {
            Pickup(other);
            FindObjectOfType<AudioManager>().Play("Pickup");
            PlayerManager.collectiblevalue++;
            PlayerManager.collectiblecount++;
            PlayerManager.collectiblecount += 9;
            Destroy(gameObject);           
        }

        if (other.CompareTag("Player B"))
        {
            Pickup(other);
            FindObjectOfType<AudioManager>().Play("Pickup");
            PlayerManager.collectiblevalue++;
            PlayerManager.collectiblecount++;
            PlayerManager.collectiblecount += 9;
            Destroy(gameObject);             
        }
    }
    void Pickup(Collider2D Player)
    {
        WorldDamage stats = Player.GetComponent<WorldDamage>();
        if (stats.CurrentHealth < stats.maxHealth)
        {
            stats.CurrentHealth += HealthBoost;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
        else if (stats.CurrentHealth > stats.maxHealth)
        {
            HealthBoost = 0;
            stats.CurrentHealth += HealthBoost;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
        Destroy(gameObject);
        //Debug.Log("Power Uped!");
    }
}
