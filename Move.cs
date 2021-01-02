using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float JumpHeight = 1f;
    public float moveSpeed = 5f;

    public bool isGrounded = false;
    private bool isRight = true;

    private int Jumpsleft;
    public int extraJumpsValue;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public Animator animator;
    public float moving = 0;
    //public BoxCollider2D BoxCollide;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        Jumpsleft = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        AnimatorMove();
        //get horizontal input and move character
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        //rb.AddForce();
        Flip(rb.velocity);

    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && Jumpsleft > 0)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            //rb.velocity = Vector2.up * JumpHeight;
            Jumpsleft--;
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        /*else if (Input.GetButtonDown("Jump") && Jumpsleft == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpHeight;
        } */
        //if on ground set isjumping parameter to false and give double jump
        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
            Jumpsleft = extraJumpsValue;
            animator.SetBool("IsGrounded", true);

        }
        //if not grounded set isjumping to true
        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsGrounded", false);
        }
        if (rb.velocity.y < -0.1)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }
        /*
        if (Input.GetButtonDown("Jump") && Jumpsleft > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpHeight), ForceMode2D.Impulse);
            Jumpsleft--;
        }
        */
    }
    private void AnimatorMove()
    {
        //check if character is grounded and running and change animator variable
        if (Input.GetAxis("Horizontal") != 0 && isGrounded == true)
        {
            moving = 1;
        }
        else
        {
            moving = 0;
        }
        //set animator variable speed to movement value
        animator.SetFloat("Speed", moving);
    }
    private void Flip(Vector2 movement)
    {
        if (movement.x < 0 && isRight == true)
        {
            //transform.Rotate(0f, 180f, 0f);
            sr.flipX = true;
            isRight = false;
        }
        else if (movement.x > 0 && isRight == false)
        {
            //transform.Rotate(0f, 180f, 0f);
            sr.flipX = false;
            isRight = true;
        }
    }
}
   