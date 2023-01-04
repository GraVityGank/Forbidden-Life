using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAction : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;

    public float attackrange = 0.5f;
    public int attackdamage = 40;

    public LayerMask EnemyLayers;

    public float attackrate = 2f;
    float nextattacktime = 0f;

    void Update()
    {
        if (Time.time >= nextattacktime)

            if (CrossPlatformInputManager.GetButtonDown("Dig") || Input.GetKey(KeyCode.Z))
        {
            Attack();
            nextattacktime = Time.time + .5f / attackrate;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        //FindObjectOfType<AudioManager>().Play("Digging");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, EnemyLayers);

        if (attackdamage > 200)
        {
            FindObjectOfType<AudioManager>().Play("Godsmack");
        }

        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(attackdamage);
        }
    }

    void OndrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
    
}
