using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingLine : Pickup
{
    //Script for handling the line that marks the end of the level

    void Update()
    {
        //Move constantly towards pigeon
        move();
    }

    //Load EndView scene after reaching pigeon
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            SceneManager.LoadScene("EndView");
        }
    }
}
