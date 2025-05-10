using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    //Script describing one item in the shop

    public Text txtPrice;    //Label showing price of the item
    public Text txtMoney;    //Label showing how much money do you have
    public int weaponIndex;  //Index of the item, matching our normal order of weapons from milanote

    void Start()
    {
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
    }

    //If item in the shop was clicked, check if you have enough money to buy it and do it
    public void buttonClicked()
    {
        int price;
        if(int.TryParse(txtPrice.text, out price))
        {
            if (int.Parse(txtMoney.text) >= price)
            {

                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);
                txtMoney.text = PlayerPrefs.GetInt("money").ToString();
                SerializeAndBuy();
            }
        }
    }

    //Serialize and save bought item in PlayerPrefs
    void SerializeAndBuy()
    {
        string weapons = "1000000";
        char[] weaponsArray = weapons.ToCharArray();
        weaponsArray[weaponIndex] = '1';
        weapons = new string(weaponsArray);
        PlayerPrefs.SetString("weapons", weapons);
        txtPrice.text = "Bought!";
    }
}
