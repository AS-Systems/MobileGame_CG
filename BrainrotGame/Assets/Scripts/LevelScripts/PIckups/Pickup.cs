using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Script for pickups that are spawned in the level. 
    //Every pickup inherits from it.

    public float speed = 5;
    public Pigeon pigeon;

    //Move with constant speed towards player.
    protected void move()
    {
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
    }

    //Function to be overriden to manage what happens when the player picks up the item.
    virtual protected void picked()
    {

    }
}
