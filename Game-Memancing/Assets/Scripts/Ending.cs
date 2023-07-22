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
    public GameObject panelHitam;
    public Text narasi;

    // Start is called before the first frame update
    void Start()
    {
        tetapBtn.SetActive(false);
        pulangBtn.SetActive(false);
        panelHitam.SetActive(false);
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
        narasi.text = "Pina memilih untuk menetap dan melanjutkan petualangannya bersama Millo";
        videoPlayer.loopPointReached += kembali;
    }

    public void pulang()
    {
        tetapBtn.SetActive(false);
        pulangBtn.SetActive(false);
        videoPlayer.clip = clipPulang;
        narasi.text = "Pina akhirnya berhasil pulang ke rumahnya...";
        videoPlayer.loopPointReached += kembali;
    }

    void popupBtn(VideoPlayer vp)
    {
        tetapBtn.SetActive(true);
        pulangBtn.SetActive(true);
    }

    void kembali(VideoPlayer vp)
    {
        panelHitam.SetActive(true);
        StartCoroutine(delay());
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}
