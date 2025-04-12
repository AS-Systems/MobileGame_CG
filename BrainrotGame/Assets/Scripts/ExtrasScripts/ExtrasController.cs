using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExtrasController : MonoBehaviour
{
    //Script for handling showing extras scene
    //Each "page" is a panel containing text and images

    //Index of the currently shown panel
    public int actualPanelIndex;
    //Array of all panels that can be shown
    public GameObject[] panels;

    void Start()
    {
        //Hide all panels except the first one
        actualPanelIndex = 0;
        for(int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void NextButtonClicked()
    {
        //Hide actual panel
        panels[actualPanelIndex].gameObject.SetActive(false);

        //Calculate if we're already at the last panel
        if (actualPanelIndex == panels.Length - 1)
        {
            actualPanelIndex = 0;
        }
        else
        {
            actualPanelIndex++;
        }
        //Show next/first panel
        panels[actualPanelIndex].SetActive(true);
      
    }

    public void PreviousButtonClicked()
    {
        panels[actualPanelIndex].gameObject.SetActive(false);

        if (actualPanelIndex == 0)
        {
            actualPanelIndex = panels.Length -1;
        }
        else
        {
            actualPanelIndex--;
        }
        panels[actualPanelIndex].SetActive(true);
    }


}
