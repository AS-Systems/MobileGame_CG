using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Pickup
{
    //Script for the health pickup

    void Start()
    {
        //Finds the pigeon object in the scene 
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

    override protected void picked()
    {
        //Add no more health than it's full value, destroy pickup
        if(pigeon.health >= 100)
        {
            Destroy(gameObject);
        }
        else if (pigeon.health + 10 > 100)
        {
            pigeon.health = pigeon.maxHealth;
        }
        else
        {
            pigeon.health += 10;
        }
        Destroy(gameObject);

    }
}
