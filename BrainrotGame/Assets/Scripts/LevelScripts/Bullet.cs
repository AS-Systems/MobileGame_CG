using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject pigeon;
    public float damage;
    public float speed;
    public Enemy enemy;
    public HeldWeapon weapon;
    public float destroyZDistance;

    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon");
        weapon = FindWeaponInChildren(pigeon.transform);
        speed = weapon.bulletSpeed;
        damage = weapon.damage;
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (this.transform.position.z > destroyZDistance)
        {
            Destroy(gameObject);
        }
    }

    void move()
    {
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += movement;
    }

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
