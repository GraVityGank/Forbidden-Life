using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public float Attack;
    public Animator animator;
    private float nextDamage;
    public float DamDelay;

    void Start()
    {
        nextDamage = Time.time + DamDelay;
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Hurt");
            Damage(other);
            nextDamage = Time.time + DamDelay;
        }
        if (other.gameObject.tag == "Player F")
        {
            FindObjectOfType<AudioManager>().Play("Female Hurt");
            Damage(other);
            nextDamage = Time.time + DamDelay;
        }
        if (other.gameObject.tag == "Player B")
        {
            FindObjectOfType<AudioManager>().Play("Blockboy Hurt");
            Damage(other);
            nextDamage = Time.time + DamDelay;
        }
        else if (other.gameObject.tag == "Monster")
        {
            Destroy(other.gameObject);
        }
    }
    void Damage(Collider2D Player)
    {
        WorldDamage stats = Player.gameObject.GetComponent<WorldDamage>();

        if (stats.CurrentHealth < stats.maxHealth)
        {
            Debug.Log("Yowza!");
            Attack = Attack;
            stats.CurrentHealth -= Attack;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
        else if (stats.CurrentHealth > stats.maxHealth)
        {
            Attack = 0;
            stats.CurrentHealth += Attack;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
    }
    void AwatMuna()
    {
        //Monster Ignore Collision
        //Physics2D.IgnoreLayerCollision(8, 3);
        //Physics2D.IgnoreLayerCollision(8, 3);
        //Physics2D.IgnoreLayerCollision(9, 3);
    }

}
    