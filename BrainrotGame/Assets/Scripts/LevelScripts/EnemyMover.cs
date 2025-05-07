using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //Script for handling enemies movement.
    
    public float speed;     //speed of movement
    public float rotX;      //Rotations to be set
    public float rotY;
    public float rotZ;

    void Start()
    {
        //Rotate as specified in the inspector
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }

    void Update()
    {
        move();
    }

    //Move with constant speed towards player.
    void move()
    {
        Vector3 movement = new Vector3(0, 0, -speed * Time.deltaTime);
        transform.position += movement;
    }

    //Stay in place after reaching the player.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            speed = 0;
        }
    }
}
