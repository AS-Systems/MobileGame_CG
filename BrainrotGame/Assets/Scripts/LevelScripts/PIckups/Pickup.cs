using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float speed = 5;
    public Pigeon pigeon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void move()
    {
        transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
    }


    virtual protected void picked()
    {

    }
}
