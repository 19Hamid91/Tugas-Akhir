using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescManager : MonoBehaviour
{
    public CardManager cardManager;
    public GameObject[] inputField;
    // Start is called before the first frame update
    private void Start()
    {
        FillDescription();
    }

    private void FillDescription()
    {
            //Assign nama ikan
            inputField[0].transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text = cardManager.cards[Data.indexIkan].nama;

            //Assign gambar ikan
            inputField[0].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cardManager.cards[Data.indexIkan].cardSprite;

            //Assign habitat
            inputField[0].transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = cardManager.cards[Data.indexIkan].habitat;

            //Assign kandungan
            inputField[0].transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = cardManager.cards[Data.indexIkan].kandungan;

            //Assign rekomendasi masakan
            inputField[0].transform.GetChild(1).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = cardManager.cards[Data.indexIkan].rekomendasiMakanan;
    }
}
