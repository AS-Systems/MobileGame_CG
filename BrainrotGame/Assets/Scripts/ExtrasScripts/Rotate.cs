using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Script that constantly rotates any object it's attached to.
    //You can change the speed and axis of rotation in the inspector.

    public Vector3 rotationSpeed = new Vector3(0, 30, 0); // Y-axis rotation

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
