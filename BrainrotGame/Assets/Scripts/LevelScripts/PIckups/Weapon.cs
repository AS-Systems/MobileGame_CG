using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Pickup
{
    public int weaponIndex;
    public PigeonMover pigeonMover;
    public GameObject weaponHolder;

    Vector3 originalWeaponHolderPos;


    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
        pigeonMover = GameObject.Find("Pigeon").GetComponent<PigeonMover>();
        weaponHolder = GameObject.Find("WeaponHolder");

       // originalWeaponHolderPos = weaponHolder.transform.position;

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

        if (weaponIndex == 0)
        {
          //  Vector3 offset = new Vector3(0.47f, 0.15f, 0f);
         //   weaponHolder.transform.position = originalWeaponHolderPos + offset;
        }
        if (weaponIndex == 6)
        {
            weaponHolder.transform.rotation = Quaternion.Euler(-90, 90, 0);
        }
        else { weaponHolder.transform.rotation = Quaternion.Euler(-90, 0, 0);/* weaponHolder.transform.position = originalWeaponHolderPos;*/ }

        GameObject newWeapon = Instantiate(pigeon.weaponsModels[weaponIndex], weaponHolder.transform.position, weaponHolder.transform.rotation, weaponHolder.transform);



        pigeon.weaponIndex = weaponIndex;
        pigeon.damage = pigeon.weaponsDamages[weaponIndex];
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
