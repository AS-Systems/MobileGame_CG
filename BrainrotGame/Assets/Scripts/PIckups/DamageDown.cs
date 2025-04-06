using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDown : Pickup
{
    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();
        }
    }

    override protected void picked()
    {
        pigeon.damage -= 5;
        Destroy(gameObject);
    }
}
