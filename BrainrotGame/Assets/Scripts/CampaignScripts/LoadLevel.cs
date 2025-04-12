using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Script for loading levels after buttons are pressed.
    //Level number must be set in the inspector in button properties.

    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClickedLoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
