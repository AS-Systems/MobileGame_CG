using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Pickup
{
    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
    }

    // Update is called once per frame
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
