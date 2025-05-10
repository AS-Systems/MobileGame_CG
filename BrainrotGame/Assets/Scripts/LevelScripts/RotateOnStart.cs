using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnStart : MonoBehaviour
{
    //Script for ensuring proper prefabs rotation after instanitating.
    //Developer changes rotation and position in the inspector and can choose which one should be used.

    public bool rotate;     //Enable setting rotation by this script
    public bool positionate;//Enable setting position by this script

    public float rotX;      //Rotations to be set
    public float rotY;
    public float rotZ;

    public float posX;      //Position to be set
    public float posY;
    public float posZ;

    //Use rotation and position only once after initialization
    void Start()
    {
        if(rotate)
        {
            transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
        }
        if(positionate)
        {
            transform.position += new Vector3(posX, posY, posZ);
        }

    }

}
