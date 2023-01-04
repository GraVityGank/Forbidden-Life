using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runspeed = 40f;
    float horizontalMove = 0f;
    float PCmove = 0f;
    bool jump = false;

    void Update()
    {
        transform.position += Vector3.zero;

        horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runspeed;
        PCmove = Input.GetAxis("Horizontal") * runspeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //animator.SetFloat("Speed", Mathf.Abs(PCmove));

        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        controller.Move(PCmove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    
}
