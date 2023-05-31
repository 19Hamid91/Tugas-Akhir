using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroQuizManager : MonoBehaviour
{
    public Text WaktuTxt;
    public Text JmlSoalTxt;
    private int Waktu;
    private int JmlSoal;
    // Start is called before the first frame update
    void Start()
    {
        switch (Data.Level)
        {
            case 3:
                Waktu = 8;
                JmlSoal = 15;
                break;
            case 2:
                Waktu = 7;
                JmlSoal = 10;
                break;
            default:
                Waktu = 5;
                JmlSoal = 5;
                break;
        }
        UIUpdate();
    }

    public void UIUpdate()
    {
        WaktuTxt.text = Waktu+" Menit";
        JmlSoalTxt.text = JmlSoal.ToString();
    }
}
