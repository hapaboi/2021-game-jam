using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public int moveSpeed;
    public GameObject deathEffect;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    private int Direction = -1;
    private float lerpTime = 0;
    private float lerpDuration = 100f;

    public void TakeDamage(int damage)
    {
        //take damage
        health -= damage;
        //damage color
        lerpTime = 0;
        sr.material.color = Color.red; 
        StartCoroutine(ColorReset());
        Debug.Log("damagetaken");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        rb.velocity = new Vector2(Direction * moveSpeed, rb.velocity.y);
    }

    IEnumerator ColorReset()
    {
        while (lerpTime < lerpDuration)
        {
            sr.material.color = Color.Lerp(sr.material.color, Color.white, lerpTime / lerpDuration);
            lerpTime += Time.deltaTime;
            yield return null;
        }
        sr.material.color = Color.white;
    }
}
