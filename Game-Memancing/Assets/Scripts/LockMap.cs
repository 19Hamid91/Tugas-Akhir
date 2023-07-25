using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockMap : MonoBehaviour
{
    public GameObject[] mapObject;
    public GameObject[] pin;
    public Sprite[] mapLocked;
    public GameObject bgMap;
    private int unlockedMap;
    // Start is called before the first frame update
    void Start()
    {
        unlockedMap = 1;
        bgMap.GetComponent<Image>().sprite = mapLocked[0];
        if (Data.PapuaLevel == 4)
        {
            unlockedMap += 5;
            bgMap.GetComponent<Image>().sprite = mapLocked[4];
        }
        else if (Data.SulawesiLevel == 4)
        {
            unlockedMap += 4;
            bgMap.GetComponent<Image>().sprite = mapLocked[4];
        }
        else if (Data.SumatraLevel == 4)
        {
            unlockedMap += 3;
            bgMap.GetComponent<Image>().sprite = mapLocked[3];
        }
        else if (Data.KalimantanLevel == 4)
        {
            unlockedMap += 2;
            bgMap.GetComponent<Image>().sprite = mapLocked[2];
        }
        else if (Data.JawaLevel == 4)
        {
            unlockedMap += 1;
            bgMap.GetComponent<Image>().sprite = mapLocked[1];
        }
        lockMap();
    }

    public void lockMap()
    {
        for (int i = 0; i < mapObject.Length - unlockedMap; i++)
        {
            // lock map
            mapObject[i].transform.GetChild(2).gameObject.SetActive(false);

            // hide pin
            pin[i].SetActive(false);
        }
    }

}