using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    public AudioClip quiz;

    void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Story")
        {
           AudioListener.pause = true;
        }   
        else if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            AudioListener.pause = Data.muted;
        }
        else if(SceneManager.GetActiveScene().name == "Quiz")
        {
            GetComponent<AudioSource>().clip = quiz;
        }
    }
}
