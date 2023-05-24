using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgSelector : MonoBehaviour
{
    public Sprite bgLvl1;
    public Sprite bgLvl2;
    public Sprite bgLvl3;
    // Start is called before the first frame update
    void Start()
    {
        switch (Data.Level)
        {
            case 1:
                gameObject.GetComponent<Image>().sprite = bgLvl1;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = bgLvl2;
                break;          
            case 3:
                gameObject.GetComponent<Image>().sprite = bgLvl3;
                break;
            default:
                gameObject.GetComponent<Image>().sprite = bgLvl1;
                break;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
