using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExtrasController : MonoBehaviour
{
    public int actualPanelIndex;
    public GameObject[] panels;

    // Start is called before the first frame update
    void Start()
    {
        actualPanelIndex = 0;
        for(int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void NextButtonClicked()
    {
        panels[actualPanelIndex].gameObject.SetActive(false);

        if (actualPanelIndex == panels.Length - 1)
        {
            actualPanelIndex = 0;
        }
        else
        {
            actualPanelIndex++;
        }
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
