using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    //public Transform weaponPos;
    public GameObject weapon;
    public LayerMask isEnemy;
    //public Animator camAnim;
    //public Animator playerAnim;
    public Vector2 weaponRange;
    public float weaponAngle;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //do tan y/x * rad2Deg to find angle of rotaiton
        float RotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, RotationZ);
        //time between attack + circle hurtbox
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                //camAnim.SetTrigger("shake");
                //playerAnim.SetTrigger("attack");
                //creates circle that gets a list of all colliders that fall within the area
                Collider2D[] AmountEnemies = Physics2D.OverlapBoxAll(weapon.transform.position, weaponRange, weaponAngle, isEnemy);
                for (int i = 0; i < AmountEnemies.Length; i++)
                {
                    //loop for how many enemies there are, pass damage into enemies damage function and lower health
                    AmountEnemies[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else 
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireCube(weapon.transform.position, weaponRange);
    }
}
