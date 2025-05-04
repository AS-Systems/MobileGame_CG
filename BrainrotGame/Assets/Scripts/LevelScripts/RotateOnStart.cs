using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnStart : MonoBehaviour
{
    public bool rotate;
    public bool positionate;
    public float rotX;
    public float rotY;
    public float rotZ;

    public float posX;
    public float posY;
    public float posZ;

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
