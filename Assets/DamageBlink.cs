using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlink : MonoBehaviour
{
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }
        //else if (startBlinking != true)
        //{
        //    sprite.color = new Color(1, 1, 1, 1);
        //}
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster") //change according to your game
        {
            sprite.color = new Color(1, 0, 0, 1);
            startBlinking = true;
        }
        else if (other.gameObject.tag == "Enemy")
        {
            sprite.color = new Color(1, 1, 1, 1);
            startBlinking = false;
        }
        startBlinking = false;

    }
    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false; //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //make changes
            }
        }
    }
}
