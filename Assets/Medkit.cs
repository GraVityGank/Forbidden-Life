using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float HealthBoost = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Regeneration");
            Pickup(other);
        }
        if (other.CompareTag("Player F"))
        {
            FindObjectOfType<AudioManager>().Play("Regeneration");
            Pickup(other);
        }
        if (other.CompareTag("Player B"))
        {
            FindObjectOfType<AudioManager>().Play("Regeneration");
            Pickup(other);
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
