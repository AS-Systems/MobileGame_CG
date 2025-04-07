using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text txtMoney;
    public Text[] itemsPrices;
    

    public int money;

    // Start is called before the first frame update
    void Start()
    {
        txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
        money = PlayerPrefs.GetInt("money", 0);
        txtMoney.text = money.ToString();
        LoadBoughtItems();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadBoughtItems()
    {
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
