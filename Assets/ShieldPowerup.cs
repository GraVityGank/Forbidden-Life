using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public GameObject Monster;
    public float duration = 5f;
    //public GameObject Monster = GameObject.FindWithTag("Monster");

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider2D Player)
    {
        Patrol stats = Monster.GetComponent<Patrol>();
        //stats.speed = 0;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.speed = 2;

        Destroy(gameObject);
        //Debug.Log("Power Uped!");
    }
}


