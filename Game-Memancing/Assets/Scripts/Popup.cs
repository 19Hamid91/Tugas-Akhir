using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public List<GameObject> popups = new List<GameObject>();

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
}
