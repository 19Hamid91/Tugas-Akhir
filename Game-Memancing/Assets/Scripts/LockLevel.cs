using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevel : MonoBehaviour
{
    public GameObject[] levelObject;
    private int openLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (Data.Tempat == "GamePlayJawa")
        {
            openLevel = Data.JawaLevel;
        }
        else if (Data.Tempat == "GamePlaySumatra")
        {
            openLevel = Data.SumatraLevel;
        }
        else if (Data.Tempat == "GamePlayKalimantan")
        {
            openLevel = Data.KalimantanLevel;
        }
        else
        {
            openLevel = 1;
        }
        lockLevel();
    }

    public void lockLevel()
    {
        for (int i = 0; i < levelObject.Length - openLevel; i++)
        {
            // disable button
            levelObject[i].GetComponent<Button>().enabled =false;
            // change collor
            levelObject[i].GetComponent<Image>().color = new Color(255,0,0);
            // deactivate level number
            levelObject[i].transform.GetChild(0).gameObject.SetActive(false);
            // activate lock image
            levelObject[i].transform.GetChild(1).gameObject.SetActive(true);
        }
    }

}