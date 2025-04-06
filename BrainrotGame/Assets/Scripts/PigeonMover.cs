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
    public GameObject weaponHolder;

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

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = GetTouchWorldPosition();

            touchPosition.z = transform.position.z; // Ensure Z stays the same

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                    break;

                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    float newX = Mathf.Lerp(transform.position.x, touchPosition.x, Time.deltaTime * 10f);
                    transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                    break;
            }
        }



        bulletFrequency = weaponsFrequencies[weaponIndex];

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

    Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPosScreen = Input.GetTouch(0).position;

        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosScreen.x, touchPosScreen.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));


        return touchPosWorld;
    }

    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, weaponHolder.transform.position, Quaternion.identity);
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
