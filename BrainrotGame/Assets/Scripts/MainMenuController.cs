using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
