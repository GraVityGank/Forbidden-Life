using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerDig : MonoBehaviour
{
    public Animator animator;
    public Transform digpoint;

    public float digrange = 0.5f;
    public int digdamage = 40;

    public LayerMask EnemyLayers;

    public float digrate = 2f;
    float nextdigtime = 0f;

    void Update()
    {
        if (Time.time >= nextdigtime)
            if (CrossPlatformInputManager.GetButtonDown("DigDown") || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Z)))
            {
                Attack();
                nextdigtime = Time.time + 1f / digrate;
            }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        //FindObjectOfType<AudioManager>().Play("Digging");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(digpoint.position, digrange, EnemyLayers);

        if (digdamage > 200)
        {
           FindObjectOfType<AudioManager>().Play("Godsmack");
        }

        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(digdamage);
        }
    }

    void OndrawGizmosSelected()
    {
        if (digpoint == null)
            return;

        Gizmos.DrawWireSphere(digpoint.position, digrange);
    }

}

