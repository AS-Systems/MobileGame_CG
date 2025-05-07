using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : HeldWeapon
{
    public float numberOfBullets;           //How many bullets in the series may be shot
    public float timeToReload;              //How long it takes to reload the series
    private float timeSinceReloadStarted;    //How long since we started reloading

    private void Update()
    {
        shoot();
        time += Time.deltaTime;
        timeSinceReloadStarted += Time.deltaTime;
    }

    protected override void shoot()
    {
        //If you can't shoot yet return, else Instanitate bullet and count how many are left.
        if (time < reloadSpeed || timeSinceReloadStarted < timeToReload)
        {
            return;
        }
        else
        {
            GameObject newBullet = Instantiate(bullet, weaponHolder.transform.position, Quaternion.identity);
            time = 0;
            numberOfBullets--;
            if(numberOfBullets == 0)
            {
                timeSinceReloadStarted = 0;
                numberOfBullets = 6;
            }
        }
    }
}

