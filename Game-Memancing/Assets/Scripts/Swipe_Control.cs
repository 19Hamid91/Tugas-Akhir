using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Swipe_Control : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float [] pos;
    int posisi = 0;
    public GameObject BtnKiri;
    public GameObject BtnKanan;
    public GameObject btnOK;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GamePlayJawa" && Data.tutorialWatched == false)
        {
            btnOK.SetActive(false);
        }
    }

    public void next()
    {
        if (posisi < pos.Length -1)
        {
            posisi += 1;
            scroll_pos = pos[posisi];
        }
    }

    public void prev()
    {
        if (posisi > 0)
        {
            posisi -= 1;
            scroll_pos = pos[posisi];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos [i] = distance * i;
        }

        if (Input.GetMouseButton (0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        } else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos [i] + (distance / 2) && scroll_pos > pos [i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp (scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                    posisi = i;

                    if (posisi == 0)
                    {
                        BtnKiri.SetActive(false);
                        if (SceneManager.GetActiveScene().name == "GamePlayJawa")
                        {
                            btnOK.SetActive(false);
                        }
                    }
                    else if (posisi == 3)
                    {
                        BtnKanan.SetActive(false);
                        if (SceneManager.GetActiveScene().name == "GamePlayJawa")
                        {
                            btnOK.SetActive(true);
                        }
                    }
                    else
                    {
                        if (SceneManager.GetActiveScene().name == "GamePlayJawa")
                        {
                            btnOK.SetActive(false);
                        }
                        BtnKiri.SetActive(true);
                        BtnKanan.SetActive(true);
                    }
                }
            }
        }
    }
}
