using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadData : MonoBehaviour
{
    public Data data = new Data();

    private void Start() 
    {
        LoadFromJson();
    }

    public void SaveToJson()
    {
        string gameData = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/PinaPemancingData.json";
        Debug.LogError(filePath);
        File.WriteAllText(filePath, gameData);
        Debug.Log("Data Saved");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/PinaPemancingData.json";
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            string gameData = File.ReadAllText(filePath);

            data = JsonUtility.FromJson<Data>(gameData);
            Debug.Log("Data Loaded");
        }
        else
        {
            return;
        }
        
    }
}
