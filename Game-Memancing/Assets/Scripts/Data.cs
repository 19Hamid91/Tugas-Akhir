using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public static string Tempat;
    public static int Level;
    public static int indexIkan;
    public static string lastScene;

    public static int direction;
    public static float speed;
    public static bool isInsideArea;

    public static List<int> unlockedFish = new List<int>();
    public static int[] probabilitas =  new int[] {1,1,1,1,1,1,1,1,1,2};
    // public List<string> dataIkan = new List<string>();   
}
