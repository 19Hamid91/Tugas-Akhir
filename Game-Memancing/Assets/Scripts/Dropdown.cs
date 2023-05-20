using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public GameObject btnInfo;
    public GameObject btnTutorial;
    private bool hide = true;
    // Start is called before the first frame update
    void Start()
    {
        DropdownUI();
    }

    public void OnTap()
    {
        if(hide)
        {
            hide = false;
        }
        else
        {
            hide = true;
        }

        DropdownUI();
    }
    private void DropdownUI()
    {
        if(hide)
        {
            btnInfo.SetActive(false);
            btnTutorial.SetActive(false);
        }
        else
        {
            btnInfo.SetActive(true);
            btnTutorial.SetActive(true);
        }
        
    }
}
