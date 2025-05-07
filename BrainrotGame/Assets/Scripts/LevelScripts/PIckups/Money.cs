using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : Pickup
{
    //Money pickup script.

    public Text txtMoney;   //Label showing how much money was earned during the level

    void Start()
    {
        //Find Pigeon and Money label in the scene
        pigeon = GameObject.Find("Pigeon").GetComponent<Pigeon>();
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
    }

    void Update()
    {
        //Move function inherited from Pickup
        move();
    }

    //Add money by setting label and PlayerPrefs, destroy pickup
    protected override void picked()
    {
        pigeon.money++;
        PlayerPrefs.SetInt("moneyLevel", pigeon.money);
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1);
        txtMoney.text = pigeon.money.ToString();
        Destroy(gameObject);
    }

    //Go to picked() function when collides with the pigeon
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            picked();
        }
    }
}
