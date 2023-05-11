using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFishData : MonoBehaviour
{
    public TextAsset FishDataJSON;

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
    // Start is called before the first frame update
    public void Start()
    {
        myFishDataList = JsonUtility.FromJson<FishDataList>(FishDataJSON.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
