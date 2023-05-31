using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{

    public Text textTimer;
    public float Waktu;

    void Start()
    {
        switch (Data.Level)
        {
            case 3:
                Waktu = 480;
                break;
            case 2:
                Waktu = 420;
                break;
            default:
                Waktu = 300;
                break;
        }
    }

    void SetText()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        textTimer.text = Menit.ToString("00")+":"+Detik.ToString("00");
    }

    float s;

    // Update is called once per frame
    void Update()
    {
        if (Waktu == 0)
        {
            Data.timeIsUp = true;
        }
        s += Time.deltaTime;
        if(s >= 1)
        {
            Waktu--;
            s = 0;
        }

        SetText();
    }
}
