using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescManager : MonoBehaviour
{
    public CardManager cardManager;
    // public GameObject[] inputField;
    public GameObject spriteIkan;
    public GameObject gambarIkan;
    public Text namaIkan;
    public Text habitat;
    public Text kandungan;
    public Text rekomendasiMakanan;
    // Start is called before the first frame update
    private void Start()
    {
        FillDescription();
    }

    private void FillDescription()
    {
            //Assign nama ikan
            namaIkan.text = cardManager.cards[Data.indexIkan].nama;

            //Assign sprite ikan
            spriteIkan.GetComponent<Image>().sprite = cardManager.cards[Data.indexIkan].cardSprite;

            //Assign gambar ikan
            gambarIkan.GetComponent<Image>().sprite = cardManager.cards[Data.indexIkan].cardReal;

            //Assign habitat
            habitat.text = cardManager.cards[Data.indexIkan].habitat;

            //Assign kandungan
            kandungan.text = cardManager.cards[Data.indexIkan].kandungan;

            //Assign rekomendasi masakan
            rekomendasiMakanan.text = cardManager.cards[Data.indexIkan].rekomendasiMakanan;
    }
}
