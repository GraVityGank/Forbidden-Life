using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GasMaskPowerup : MonoBehaviour
{
    public float duration = 5f;
    public GameObject GasMask;

    void Start()
    {
        GasMask = GameObject.FindGameObjectWithTag("GasGUI");
    }
    void Update()
    {
        GasMask = GameObject.FindGameObjectWithTag("GasGUI");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
            FindObjectOfType<AudioManager>().Play("Gas");
            //GasMask.SetActive(true);
        }
        if (other.CompareTag("Player F"))
        {
            StartCoroutine(Pickup(other));
            FindObjectOfType<AudioManager>().Play("Gas");
            //GasMask.SetActive(true);
        }
        if (other.CompareTag("Player B"))
        {
            StartCoroutine(Pickup(other));
            FindObjectOfType<AudioManager>().Play("Gas");
            //GasMask.SetActive(true);
        }
    }
    IEnumerator Pickup(Collider2D Player)
    {
        WorldDamage stats = Player.GetComponent<WorldDamage>();
        GasMask.GetComponent<Image>().enabled = true;

        if (stats.isHpLow = true)
        {
            stats.CurrentHealth += Time.deltaTime;
            stats.healthBar.SetHealth(stats.CurrentHealth);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }

        yield return new WaitForSeconds(duration);

        GasMask.GetComponent<Image>().enabled = false;
        stats.isHpLow = !true;
        stats.CurrentHealth -= Time.deltaTime * stats.decreasePerSecond / 60f;

        Destroy(gameObject);
    }
}
    
