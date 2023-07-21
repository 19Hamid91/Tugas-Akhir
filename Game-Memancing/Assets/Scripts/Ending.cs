using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public VideoClip clipMenetap;
    public VideoClip clipPulang;
    public VideoPlayer videoPlayer;
    public GameObject tetapBtn;
    public GameObject pulangBtn;
    // Start is called before the first frame update
    void Start()
    {
        tetapBtn.SetActive(false);
        pulangBtn.SetActive(false);
        videoPlayer.loopPointReached += popupBtn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menetap()
    {
        tetapBtn.SetActive(false);
        pulangBtn.SetActive(false);
        videoPlayer.clip = clipMenetap;
        videoPlayer.loopPointReached += map;
    }

    public void pulang()
    {
        tetapBtn.SetActive(false);
        pulangBtn.SetActive(false);
        videoPlayer.clip = clipPulang;
        videoPlayer.loopPointReached += mainMenu;
    }

    void popupBtn(VideoPlayer vp)
    {
        tetapBtn.SetActive(true);
        pulangBtn.SetActive(true);
    }

    void mainMenu(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }

    void map(VideoPlayer vp)
    {
        SceneManager.LoadScene("Map");
    }
}
