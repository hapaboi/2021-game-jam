using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float ProjSpeed = 10f;
    public float lifeTime = 1.5f;

    public GameObject destroyEffect;

    
    private void Start()
    {
        //invokes destroy projectile after a certain amount of time
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * ProjSpeed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
