using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{
    public List<GameObject> popups = new List<GameObject>();
    private bool hide = true;

    private void Start() {
        
        if (SceneManager.GetActiveScene().name == "GamePlayJawa" && Data.tutorialWatched == false)
        {
            for (int i = 0; i < popups.Count; i++)
            {
                popups[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < popups.Count; i++)
            {
                popups[i].SetActive(false);
            }
        }
    }

    public void showPopup()
    {
        hidePopup();
        popups[0].SetActive(true);
    }
    public void hidePopup()
    {
        for (int index = 0; index < popups.Count; index++)
        {
            popups[index].SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "GamePlayJawa" && Data.tutorialWatched == false)
        {
            Data.tutorialWatched = true;
            SaveLoadData.SaveToJson();
        }
    }

    public void OnOff()
    {
        if (hide)
        {
            for (int index = 0; index < popups.Count; index++)
            {
                popups[index].SetActive(true);
            }
            hide = false;
        }
        else
        {
            hidePopup();
            hide = true;
        }
    }
}
