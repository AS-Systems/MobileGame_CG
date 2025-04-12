using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    //Script for handling settings menu

    public Toggle sound;
    public GameObject panel;

    void Start()
    {
        //Hide panel that asks if you really want to reset progresss
        panel.SetActive(false);
    }

    //TO DO: Use toggle button to mute/unmute sound in whole game.
    //Choice can be saved in PlayerPrefs
    public void Sound()
    {
        if (sound.isOn)
        {

        }
        else
        {

        }
    }    

    public void AskForReset()
    {
        //Show panel that asks if you really want to reset progress
        panel.SetActive(true);
    }

    public void ResetProgress()
    {
        //Reset all progress and hide panel
        panel.SetActive(false);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("previousMoney", 0);
        PlayerPrefs.SetInt("unlockedLevel", 0);
        PlayerPrefs.SetString("weapons", "1000000");
    }

}
