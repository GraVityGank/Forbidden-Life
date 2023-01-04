using UnityEngine;

public class PotionPowerup : MonoBehaviour
{
    public float HealthBuff = 50;

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
            stats.CurrentHealth += HealthBuff;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
        else if (stats.CurrentHealth > stats.maxHealth)
        {
            HealthBuff = 0;
            stats.CurrentHealth += HealthBuff;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
        Destroy(gameObject);
        //Debug.Log("Power Uped!");
    }
}
