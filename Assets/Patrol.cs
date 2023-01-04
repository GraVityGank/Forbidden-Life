using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform GroundDetection;
    public GameObject EnemyUnit;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 2.0f, LayerMask.GetMask("Enemy"));
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Enemy") || (other.tag == "Player") || (other.tag == "Wall") || (other.tag == "Player F") || (other.tag == "Player B"))
        {
            if (movingRight == true)
            {
                FlipRight(EnemyUnit);
            }
            else
            {
                FlipLeft(EnemyUnit);
            }
        }
    } 

    void FlipRight(GameObject EnemyUnit)
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        movingRight = false;
    }
    void FlipLeft(GameObject EnemyUnit)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        movingRight = true;
    }
}

