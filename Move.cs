using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float JumpHeight = 1f;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public bool isRight = true;
    private int Jumpsleft;
    public int extraJumpsValue;
    public Animator animator;
    public float moving = 0;
    public BoxCollider2D BoxCollide;
    private Rigidbody2D rb;
    public bool isHeadHitting = false;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollide = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Jumpsleft = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate();
        Jump();
        Crouch();
        AnimatorMove();
        //get horizontal input and move character
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        Flip(rb.velocity);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Jumpsleft > 0)
        {
            rb.velocity = Vector2.up * JumpHeight;
            Jumpsleft--;
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
        }
        //if not grounded set isjumping to true
        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }
        /*
        if (Input.GetButtonDown("Jump") && Jumpsleft > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpHeight), ForceMode2D.Impulse);
            Jumpsleft--;
        }
        */
    }
/*    void Rotate()
    {
        //ROTATION WITH Q/E
        if (isRight == true)
        {
            if (Input.GetAxis("Rotate") < 0)
            {
                transform.Rotate(Vector3.forward * 0.5f);
            }
            if (Input.GetAxis("Rotate") > 0)
            {
                transform.Rotate(Vector3.forward * -0.5f);
            }
        }
        if (isRight == false)
        {
            if (Input.GetAxis("Rotate") < 0)
            {
                transform.Rotate(Vector3.forward * -0.5f);
            }
            if (Input.GetAxis("Rotate") > 0)
            {
                transform.Rotate(Vector3.forward * 0.5f);
            }
        }
    }
    */
    void AnimatorMove()
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
    void Flip(Vector2 movement)
    {
        if (movement.x < 0 && isRight == true)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = false;
        }
        else if (movement.x > 0 && isRight == false)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = true;
        }
    }
    void Crouch()
    {
    if(Input.GetButton("Crouch"))
        {
            animator.SetBool("IsCrouching", true);
            BoxCollide.size = new Vector2(BoxCollide.size.y, 0.1256896f);
            BoxCollide.offset = new Vector2(BoxCollide.offset.y, -0.04426715f);
        }
        else if (isHeadHitting == false)
        {
            animator.SetBool("IsCrouching", false);
            BoxCollide.size = new Vector2(BoxCollide.size.y, 0.2275364f);
            BoxCollide.offset = new Vector2(BoxCollide.offset.y, 0.006656244f);
        }
    }
}
   