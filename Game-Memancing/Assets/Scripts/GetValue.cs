using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValue : MonoBehaviour
{
    public void getSceneName (string name)
    {
        Data.Tempat = name;
    }
    public void getSceneLevel (int level)
    {
        Data.Level = level;
    }
}
