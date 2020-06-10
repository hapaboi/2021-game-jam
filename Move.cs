using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float JumpHeight = 5f;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public int Jumpsleft = 1;
    public Animator animator;
    public float moving = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Jump();
        AnimatorMove();
        //get horizontal input and move character
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        
    }
    void Jump()
    {
        if (isGrounded == true)
        {
            Jumpsleft = 1;
        }
        if (Input.GetButtonDown("Jump") && Jumpsleft > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpHeight), ForceMode2D.Impulse);
            Jumpsleft--;
        }
    }
    void Rotate()
    {
        //ROTATION WITH Q/E
        if (Input.GetAxis("Rotate") < 0)
        {
            transform.Rotate(Vector3.forward * 5f);
        }
        if (Input.GetAxis("Rotate") > 0)
        {
            transform.Rotate(Vector3.forward * -5f);
        }
    }
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
}
   