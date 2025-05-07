using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : Pickup
{
    //Script for the damage up pickup

    public float damageUp = 5f; //Amount of damage to be reduced

    void Start()
    {
        //Find Pigeon in the scene
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
    }

    // Update is called once per frame
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

    //Make pigeon's damage higher and destroy the pickup
    override protected void picked()
    {
        pigeon.damage += damageUp;
        Destroy(gameObject);
    }
}
