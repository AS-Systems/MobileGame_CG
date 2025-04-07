using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Text txtPrice;
    public Text txtMoney;

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
