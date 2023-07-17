using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardDesc
{
    public Sprite cardSprite;
    public Sprite cardSiluetSprite;
    public Sprite cardReal;
    public int idIkan;
    public string nama;
    [TextArea(1,3)]
    public string habitat;
    [TextArea(1,3)]
    public string kandungan;
    [TextArea(1,3)]
    public string rekomendasiMakanan;
    public string sumber;

}
