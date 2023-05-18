using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetResult : MonoBehaviour
{
    public CardManager cardManager;
    public Sprite Gagal;
    public GameObject Header;
    public GameObject GambarIkan;
    public GameObject NamaIkan;
    // Start is called before the first frame update

    public void FillResult()
    {
        Header.GetComponent<Text>().text = "Kamu Mendapatkan Ikan!";
        NamaIkan.GetComponent<Text>().text = cardManager.cards[Data.indexIkan].nama;
        GambarIkan.GetComponent<Image>().sprite = cardManager.cards[Data.indexIkan].cardSprite;
    }
    public void IkanLepas()
    {
        Header.GetComponent<Text>().text = "Ikan Lepas";
        NamaIkan.GetComponent<Text>().text = "";
        GambarIkan.GetComponent<Image>().sprite = Gagal;
    }
}
