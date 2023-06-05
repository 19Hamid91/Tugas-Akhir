using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockMap : MonoBehaviour
{
    public GameObject[] mapObject;
    private int unlockedMap;
    // Start is called before the first frame update
    void Start()
    {
        unlockedMap = 1;
        if (Data.SumatraLevel == 4)
        {
            unlockedMap += 2;
        }
        else if (Data.JawaLevel == 4)
        {
            unlockedMap += 1;
        }
        lockMap();
    }

    public void lockMap()
    {
        for (int i = 0; i < mapObject.Length - unlockedMap; i++)
        {
            // lock map
            mapObject[i].gameObject.SetActive(false);
        }
    }

}