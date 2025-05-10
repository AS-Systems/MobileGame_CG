using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    //Script for handling settings menu

    public Toggle sound;    //Checkbox for enabling/disabling sound
    public GameObject panel;//Panel that asks if you really want to reset progress

    void Start()
    {
        //At the start hide panel that asks if you really want to reset progresss
        panel.SetActive(false);
    }

    //Save in PlayerPrefs if sound is on or off 
    public void Sound()
    {
        if (sound.isOn)
        {
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
        }
    }    

    public void AskForReset()
    {
        //Show panel that asks if you really want to reset progress
        panel.SetActive(true);
    }

    public void ResetProgress()
    {
        //Erase all progress from PlayerPrefs and hide panel
        panel.SetActive(false);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("previousMoney", 0);
        PlayerPrefs.SetInt("unlockedLevel", 0);
        PlayerPrefs.SetString("weapons", "1000000");
    }

}
