using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    public Text jmlIkan;
    public Text jmlTempat;
    int totalTempat;
    // Start is called before the first frame update
    void Start()
    {
        jmlIkan.text = Data.unlockedFish.Count +" / 30";
        if (Data.SulawesiLevel == 4)
        {
            totalTempat = 5;
        }
        else if(Data.SumatraLevel == 4)
        {
            totalTempat = 4;
        }
        else if(Data.KalimantanLevel == 4)
        {
            totalTempat = 3;
        }
        else if(Data.JawaLevel == 4)
        {
            totalTempat = 2;
        }
        else
        {
            totalTempat = 1;
        }
        jmlTempat.text = totalTempat +" / 4";
    }
}
