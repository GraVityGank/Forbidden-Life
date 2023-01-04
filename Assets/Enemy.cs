using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;


    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Digging");
        animator.SetTrigger("break");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("WASAK!");

        animator.SetBool("broken", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
