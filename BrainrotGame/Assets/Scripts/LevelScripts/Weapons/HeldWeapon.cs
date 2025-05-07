using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldWeapon : MonoBehaviour
{
    public float damage;
    public float reloadSpeed;
    public float time;
    public float bulletSpeed;

    public GameObject bullet;
    public GameObject weaponHolder;
    public GameObject pigeon;


    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon");
        weaponHolder = GameObject.Find("WeaponHolder");
        time = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        time += Time.deltaTime;
        shoot();
    }

    protected virtual void shoot()
    {
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
