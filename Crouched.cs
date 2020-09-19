using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouched : MonoBehaviour
{
    GameObject Player;
    public float checkRadius;
    public Transform crouchCheck;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player.GetComponent<Move>().isHeadHitting = Physics2D.OverlapCircle(crouchCheck.position, checkRadius);
    }
}
