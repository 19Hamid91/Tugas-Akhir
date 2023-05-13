using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardDesc
{
    public Sprite cardSprite;
    public string nama;
    public string habitat;
    [TextArea(1,3)]
    public string kandungan;
    public string rekomendasiMakanan;

}
