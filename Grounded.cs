﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask WhatisGround;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player.GetComponent<Move>().isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatisGround);
    }



    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
    */
    
}
