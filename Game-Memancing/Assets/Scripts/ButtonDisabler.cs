using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{
    public Button TheButton;
    public float ButtonReactivateDelay = 1f;
    
    // Assign this as your OnClick listener from the inspector
    public void WhenClicked() {
    TheButton.interactable = false;
    StartCoroutine(EnableButtonAfterDelay(TheButton, ButtonReactivateDelay));
    
    // Do whatever else your button is supposed to do.
    }
    
    IEnumerator EnableButtonAfterDelay(Button button, float seconds) {
    yield return new WaitForSeconds(seconds);
    button.interactable = true;
    }
}
