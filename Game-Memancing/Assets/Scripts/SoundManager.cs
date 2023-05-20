using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnImage;
    [SerializeField] Image soundOffImage;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateButton();
    }

    // Update is called once per frame
    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        UpdateButton();
    }

    private void UpdateButton()
    {
         if(muted == true)
        {
            soundOnImage.enabled = false;
            soundOffImage.enabled = true;
        }
        else
        {
            soundOnImage.enabled = true;
            soundOffImage.enabled = false;
        }
    }
}
