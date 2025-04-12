using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    //Script for handling shop menu

    //Label showing at the corner how much money do you have
    public Text txtMoney;
    //Array of labels showing prices of items
    public Text[] itemsPrices;
    //Value of money
    public int money;

    void Start()
    {
        //Load money from playerprefs and show it
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
        money = PlayerPrefs.GetInt("money", 0);
        txtMoney.text = money.ToString();
        LoadBoughtItems();
    }

    void LoadBoughtItems()
    {
        //Go through all items and if they are bought, show "Bought!" instead of price
        string weapons = PlayerPrefs.GetInt("weapons", 0).ToString();
        for (int i = 0; i < 7; i++)
        {
            if (weapons[i] == '1')
            {
                itemsPrices[i].text = "Bought!";
            }

        }
    }
}
