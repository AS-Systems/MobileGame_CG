using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnContinue : MonoBehaviour
{
    public Text txtMoney;

    int currentLevel = 1;
    int previousMoney;
    int money;

    // Start is called before the first frame update
    void Start()
    {
        previousMoney = PlayerPrefs.GetInt("previousMoney");
        money = PlayerPrefs.GetInt("money");
        currentLevel = PlayerPrefs.GetInt("level");

        txtMoney.text = (money-previousMoney).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
