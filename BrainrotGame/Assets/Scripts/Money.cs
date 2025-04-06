using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Pickup
{
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    protected override void picked()
    {
        gameController.money++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();
        }
    }
}
