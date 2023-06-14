using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public static bool muted = false;

    public static string Tempat;
    public static int Level;
    public static int indexIkan;
    public static string lastScene;

    public static int direction;
    public static float speed;
    public static bool isInsideArea;

    public static List<int> unlockedFish = new List<int>();
    public static int uniqueRate;
    public static int commonRate;

    public static bool noProgress = true;
    public static int lastIndexQuest;
    public static int lastFishCounter;
    public static int lastNamedFishCounter;
    public static string lastNamedFish;
    public static bool timeIsUp = false;

    public static int JawaLevel = 1;
    public static int SumatraLevel = 1;
    public static int KalimantanLevel = 1;
    public static int SulawesiLevel = 1;
    public static int PapuaLevel = 1;
}
