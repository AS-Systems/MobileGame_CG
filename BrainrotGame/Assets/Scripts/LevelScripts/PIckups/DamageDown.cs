using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDown : Pickup
{
    //Script for the damage down pickup

    public float damageDown = 5f; //Amount of damage to be reduced

    void Start()
    {
        //Find Pigeon in the scene
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
    }

    void Update()
    {
        //Move function inherited from Pickup
        move();
    }

    //Go to picked() function when collides with the pigeon
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();
        }
    }

    //Lower pigeon's damage and destroy the pickup
    override protected void picked()
    {
        pigeon.damage -= damageDown;
        Destroy(gameObject);
    }
}
