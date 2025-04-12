using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    //Script describing one item in the shop

    //Label showing price of the item
    public Text txtPrice;
    //Label showing how much money do you have
    public Text txtMoney;
    //Index of the item, matching our normal order of weapons from milanote
    public int weaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {        
    }

    void buttonClicked()
    {
        int price;
        if(int.TryParse(txtPrice.text, out price))
        {
            if (PlayerPrefs.GetInt("money") >= price)
            {

                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);
                txtMoney.text = PlayerPrefs.GetInt("money").ToString();
                SerializeAndBuy();
            }
            else
            {
                Debug.Log("Not enough money");
            }
        }



    }

    void SerializeAndBuy()
    {
        string weapons = "0000000";
        char[] weaponsArray = weapons.ToCharArray();
        weaponsArray[weaponIndex] = '1';
        weapons = new string(weaponsArray);
        PlayerPrefs.SetString("weapons", weapons);
        txtPrice.text = "Bought!";
    }
}
