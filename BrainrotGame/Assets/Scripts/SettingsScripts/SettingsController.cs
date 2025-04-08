using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Toggle sound;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        panel.SetActive(true);
    }

    public void ResetProgress()
    {
        panel.SetActive(false);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("previousMoney", 0);
        PlayerPrefs.SetInt("unlockedLevel", 0);
        PlayerPrefs.SetString("weapons", "1000000");
    }

}
