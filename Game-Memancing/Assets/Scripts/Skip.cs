using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
   public GameObject skip;
   public float timer;
   [SerializeField]
   VideoPlayer myVideoPlayer;
    void Start()
    {
        if (!Data.storyWatched)
        {
            Data.storyWatched = true;
            SaveLoadData.SaveToJson();
            skip.SetActive(false);
            StartCoroutine(Show(timer));
            myVideoPlayer.loopPointReached += LoadNextScene;
        } else
        {
            skip.SetActive(true);  
            myVideoPlayer.loopPointReached += LoadNextScene;
        }
    }
    
    IEnumerator Show(float delay)
    {
        yield return new WaitForSeconds(delay);
        skip.SetActive(true);
    }

    void LoadNextScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("Map");
    }
}
