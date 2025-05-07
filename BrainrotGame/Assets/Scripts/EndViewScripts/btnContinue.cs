using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnContinue : MonoBehaviour
{
    //Script for managing view after finishing level

    public Text txtMoney;     //Label showing how much money was earned during the level
    public int currentLevel;  //Number of the level that was finished to be able to restart it
    private int previousMoney;        //Money before level started
    private int money;                //Money after level finished


    void Start()
    {
        //Load values from PlayerPrefs
        previousMoney = PlayerPrefs.GetInt("previousMoney");
        money = PlayerPrefs.GetInt("money");
        currentLevel = PlayerPrefs.GetInt("level");

        //Count how much money was gained during the level
        txtMoney.text = (money-previousMoney).ToString();
    }

    //Load Capmaign scene when continue button is pressed
    public void ContinueButtonClicked()
    {
        PlayerPrefs.SetInt("previousMoney", money);
        SceneManager.LoadScene("Campaign");
    }

    //Load level again when restart button is pressed
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
