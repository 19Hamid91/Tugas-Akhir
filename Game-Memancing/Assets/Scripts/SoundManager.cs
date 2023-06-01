using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnImage;
    [SerializeField] Image soundOffImage;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButton();
        AudioListener.pause = Data.muted;
    }

    public void OnButtonPress()
    {
        if(Data.muted == false)
        {
            Data.muted = true;
            AudioListener.pause = true;
        }
        else
        {
            Data.muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButton();
    }

    private void UpdateButton()
    {
         if(Data.muted == true)
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

    private void Load()
    {
        Data.muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", Data.muted ? 1 : 0);
    }
}
