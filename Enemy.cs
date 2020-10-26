using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public GameObject deathEffect;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damagetaken");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
