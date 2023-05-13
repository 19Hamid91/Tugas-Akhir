using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CardManager cardManager;
    public GameObject[] cardSlots;
    // Start is called before the first frame update
    private void Start()
    {
        DisplayCards();
    }

    private void DisplayCards()
    {
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            //Assign nama ikan
            cardSlots[i].transform.GetChild(2).GetComponent<Text>().text = cardManager.cards[i].nama;

            //Assign gambar ikan
            cardSlots[i].transform.GetChild(3).GetComponent<Image>().sprite = cardManager.cards[i].cardSprite;
        }
    }
}