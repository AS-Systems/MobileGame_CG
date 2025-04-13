using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDown : Pickup
{
    //Script for the damage down pickup

    void Start()
    {
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
    }

    void Update()
    {
        move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();
        }
    }

    override protected void picked()
    {
        pigeon.damage -= 5;
        Destroy(gameObject);
    }
}
