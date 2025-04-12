using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnContinue : MonoBehaviour
{
    //Script for managing view after finishing level

    //Label showing how much money was earned during the level
    public Text txtMoney;
    //Number of the level that was finished to be able to restart it
    int currentLevel = 1;
    //Money before level started
    int previousMoney;
    //Money after level finished
    int money;


    void Start()
    {
        //Load values from PlayerPrefs
        previousMoney = PlayerPrefs.GetInt("previousMoney");
        money = PlayerPrefs.GetInt("money");
        currentLevel = PlayerPrefs.GetInt("level");

        //Count how much money was gained during the level
        txtMoney.text = (money-previousMoney).ToString();
    }


    public void ContinueButtonClicked()
    {
        PlayerPrefs.SetInt("previousMoney", money);
        SceneManager.LoadScene("Campaign");
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
