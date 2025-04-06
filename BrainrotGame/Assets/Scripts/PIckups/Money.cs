using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : Pickup
{
    public Text txtMoney;

    // Start is called before the first frame update
    void Start()
    {
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    protected override void picked()
    {
        pigeon.money++;
        txtMoney.text = pigeon.money.ToString();
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
