using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldWeapon : MonoBehaviour
{
    //Class from which each held weapon inherits to have it's own properties.

    public float damage;            //Damage dealt to enemies
    public float reloadSpeed;       //How long until other bullet spawns
    protected float time;              //Time since last bullet spawn
    public float bulletSpeed;       //Speed of moving the bullet

    public GameObject bullet;       //Prefab of the bullet
    public GameObject weaponHolder; //Place where the bullet spawns
    public GameObject pigeon;       //Player

    void Start()
    {
        //Find pigeon and weapon holder
        pigeon = GameObject.Find("Pigeon");
        weaponHolder = GameObject.Find("WeaponHolder");
        time = 0;
    }

    protected void Update()
    {
        //Count time and try to shoot in every frame
        time += Time.deltaTime;
        shoot();
    }

    protected virtual void shoot()
    {
        //If you can't shoot yet, return. Else Instaniate a bullet and reset the time.
        if(time < reloadSpeed)
        {
            return;
        }
        else
        {
            GameObject newBullet = Instantiate(bullet, weaponHolder.transform.position, Quaternion.identity);
            time = 0;
        }

    }
}
