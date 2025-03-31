using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Pickup
{
    public int weaponIndex;
    public Pigeon pigeon;

    // TO DO: On pickup
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();

        }
    }

    override protected void picked()
    {
        pigeon.weaponIndex = weaponIndex;
        Destroy(gameObject);
    }
    
}
