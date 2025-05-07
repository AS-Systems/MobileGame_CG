using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Script attached to the bullet prefab

    public GameObject pigeon;       //Player
    public float damage;            //How much damage will be dealt to enemy
    public float speed;             //How fast bullet moves
    public Enemy enemy;             //Enemy it touches first
    public HeldWeapon weapon;       //Script of weapon it was shot from
    public float destroyZDistance;  //Distance after which it disappears

    void Start()
    {
        //Find pigeon and weapon being its child
        pigeon = GameObject.Find("Pigeon");
        weapon = FindWeaponInChildren(pigeon.transform);
        //Take speed and damage from weapon it was shot from
        speed = weapon.bulletSpeed;
        damage = weapon.damage;
    }

    void Update()
    {
        move();

        //Destroy after some distance
        if (this.transform.position.z > destroyZDistance)
        {
            Destroy(gameObject);
        }
    }

    //Move with constant speed taken from weapon
    void move()
    {
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += movement;
    }

    //React on collision only with the enemy and take it's damage
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.takeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    // Recursively search for the object inheriting from HeldWeapon
    private HeldWeapon FindWeaponInChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // Check if the child is on the target layer
            if (child.gameObject.layer == 9)
            {
                // Try to get the Weapon component
                HeldWeapon weapon = child.GetComponent<HeldWeapon>();
                if (weapon != null)
                {
                    return weapon; // Return the found Weapon
                }
            }

            // Recursively search in the child's children
            HeldWeapon foundInChild = FindWeaponInChildren(child);
            if (foundInChild != null)
            {
                return foundInChild; // Return the found Weapon from deeper in the hierarchy
            }
        }

        return null; // No Weapon found in this branch
    }

}
