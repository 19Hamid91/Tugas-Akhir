using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaverAndLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData()
    {
        SaveLoadData.LoadFromJson();
    }
    public void SaveData()
    {
        SaveLoadData.SaveToJson();
    }

    public void ResetData()
    {
        SaveLoadData.ResetDataJson();
    }
}
