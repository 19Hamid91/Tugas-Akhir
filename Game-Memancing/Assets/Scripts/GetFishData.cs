using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetFishData : MonoBehaviour
{
    // public TextAsset FishDataJSON;

    [System.Serializable]
    public class FishData
    {
        public int id;
        public string nama;
        public string kandungan;
        public string habitat;
    }

    [System.Serializable]
    public class FishDataList
    {
        public FishData[] fishData;
    }

    public FishDataList myFishDataList = new FishDataList();

    public void SaveToJson()
    {
        string json = JsonUtility.ToJson(myFishDataList);
        File.WriteAllText(Application.persistentDataPath + "/FishDataFile.json", json);
    }
    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/FishDataFile.json");
        Data data = JsonUtility.FromJson<Data>(json);
        // for (int i = 0; i < data.Count; i++)
        // {
        // Data.dataIkan[i] = data[i];
        // }

        // Debug.Log(Data.dataIkan);
        Debug.Log(json);
    }
    // Start is called before the first frame update
    // public void Start()
    // {
    //     myFishDataList = JsonUtility.FromJson<FishDataList>(FishDataJSON.text);
    //     Debug.Log(FishDataJSON.text);
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
