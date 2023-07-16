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
    public GameObject borderIkan;
    public Text namaIkan;
    public Text habitat;
    public Text kandungan;
    public Text rekomendasiMakanan;
    public Sprite commonBorder;
    public Sprite rareBorder;
    public List<int> rareFish = new List<int>();
    // Start is called before the first frame update
    private void Start()
    {
        FillDescription();
        if (rareFish.Contains(cardManager.cards[Data.indexIkan].idIkan))
        {
            borderIkan.GetComponent<Image>().sprite = rareBorder;
        }
        else
        {
            borderIkan.GetComponent<Image>().sprite = commonBorder;
        }
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
