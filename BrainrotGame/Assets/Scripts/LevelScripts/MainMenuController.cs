using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //Functions to change scenes using buttons in main menu.

    public void changeSceneInfinite()
    {
        SceneManager.LoadScene("Level");
    }

    public void changeSceneShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void changeSceneCampaign()
    {
        SceneManager.LoadScene("Campaign");
    }

    public void changeSceneSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void changeSceneExtras()
    {
        SceneManager.LoadScene("Extras");

    }
}
