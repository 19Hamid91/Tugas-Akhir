using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public List<GameObject> popups = new List<GameObject>();
    private bool hide = true;

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
