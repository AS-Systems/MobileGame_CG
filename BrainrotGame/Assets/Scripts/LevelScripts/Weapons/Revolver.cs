using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : HeldWeapon
{
    public float numberOfBullets;
    public float timeToReload;
    public float timeSinceReloadStarted;

    private void Update()
    {
        shoot();
        time += Time.deltaTime;
        timeSinceReloadStarted += Time.deltaTime;
    }

    protected override void shoot()
    {
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

