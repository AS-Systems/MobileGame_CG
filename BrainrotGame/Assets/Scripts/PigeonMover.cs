using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PigeonMover : MonoBehaviour
{
    // *** TO DO *** //
    // Make pigeon move only left and right when user:
    // - Drags finger on screen (on mobile)
    // - Drags mouse on screen
    // - Clicks "a" and "d" or arrows on keyboard

    public GameObject bullet;
    public GameObject pigeon;

    public float[] weaponsFrequencies;

    public int weaponIndex;
    public float bulletFrequency;
    public float speed;

    private float timeSinceLastBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            moveLeft();
        }
        else if(Input.GetKey(KeyCode.A))
        {
            moveRight();
        }
        
        if(Input.GetKey(KeyCode.Space))
        {
            if(timeSinceLastBullet >= bulletFrequency)
            {
                shoot();
                timeSinceLastBullet = 0;
            }
        }

        timeSinceLastBullet += Time.deltaTime;

    }

    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, pigeon.transform.position, Quaternion.identity);
    }

    void moveLeft()
    {
        Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
        transform.position += movement;
    }

    void moveRight()
    {
        Vector3 movement = new Vector3(-speed * Time.deltaTime, 0, 0);
        transform.position += movement;
    }


}
