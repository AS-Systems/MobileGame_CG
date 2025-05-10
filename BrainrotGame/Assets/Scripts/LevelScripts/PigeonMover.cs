using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PigeonMover : MonoBehaviour
{
    //Script for handling the movement of the pigeon.

    public float speed; //Speed of moving pigeon left/right

    void Update()
    {
        //Handling touch input on mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = GetTouchWorldPosition();
            touchPosition.z = transform.position.z; 

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

        //Handling keyboard input
        if(Input.GetKey(KeyCode.D))
        {
            moveLeft();
        }
        else if(Input.GetKey(KeyCode.A))
        {
            moveRight();
        }

    }

    //Calculate how touch input translates to world position
    Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPosScreen = Input.GetTouch(0).position;

        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosScreen.x, touchPosScreen.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));


        return touchPosWorld;
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
