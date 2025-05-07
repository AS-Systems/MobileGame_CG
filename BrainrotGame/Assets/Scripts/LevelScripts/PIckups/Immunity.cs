using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : Pickup
{
    //Script for the immunity pickup.
    
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

    //Turn on immunity for the pigeon and destroy the pickup
    override protected void picked()
    {
        pigeon.immunity = true;
        Destroy(gameObject);
    }
}
