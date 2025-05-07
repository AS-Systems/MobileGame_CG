using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Pickup
{
    //Script for the weapon pickups (2D sprites).

    public int weaponIndex;             //Information which weapon to spawn (legacy solution)
    public GameObject weaponHolder;     //Empty child of pigeon that holds the weapon

    void Start()
    {
        //Find pigeon and weapon holder in the scene
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
        weaponHolder = GameObject.Find("WeaponHolder");
    }

    void Update()
    {
        //Move function inherited from Pickup
        move();
    }

    //Go to picked() function when collides with the pigeon
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();

        }
    }

    override protected void picked()
    {
        //Instanitate weapon model in the weapon holder
        GameObject newWeapon = Instantiate(pigeon.weaponsModels[weaponIndex], weaponHolder.transform.position, weaponHolder.transform.rotation, weaponHolder.transform);

        //Destroy old weapon and pickup
        foreach(Transform child in weaponHolder.transform)
        {
            if (child != newWeapon.transform)
            {
                Destroy(child.gameObject);
            }
        }
        Destroy(gameObject);
    }
    
}
