using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

public static class SaveLoadData
{
    public static void SaveToJson()
    {
        // Mengonversi variabel pada kelas Data ke dalam dictionary
        Dictionary<string, object> dataDict = new Dictionary<string, object>
        {
            { "muted", Data.muted },
            { "storyWatched", Data.storyWatched },
            { "lastNamedFish", Data.lastNamedFish },
            { "unlockedFish", Data.unlockedFish },
            { "uniqueRate", Data.uniqueRate },
            { "commonRate", Data.commonRate },
            { "noProgress", Data.noProgress },
            { "lastIndexQuest", Data.lastIndexQuest },
            { "lastFishCounter", Data.lastFishCounter },
            { "lastNamedFishCounter", Data.lastNamedFishCounter },
            { "JawaLevel", Data.JawaLevel },
            { "SumatraLevel", Data.SumatraLevel },
            { "KalimantanLevel", Data.KalimantanLevel },
            { "SulawesiLevel", Data.SulawesiLevel },
            { "PapuaLevel", Data.PapuaLevel }
        };
        string gameData = JsonConvert.SerializeObject(dataDict);
        string filePath = Application.persistentDataPath + "/PinaPemancingData.json";
        File.WriteAllText(filePath, gameData);
    }

    public static void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/PinaPemancingData.json";
        if (File.Exists(filePath))
        {
            string gameData = File.ReadAllText(filePath);

            Dictionary<string, object> dataDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(gameData);

            // Memasukkan nilai dari dictionary ke variabel pada kelas Data
            Data.muted = (bool)dataDict["muted"];
            Data.storyWatched = (bool)dataDict["storyWatched"];
            Data.lastNamedFish = (string)dataDict["lastNamedFish"];
            
            object value;

            if (dataDict.TryGetValue("uniqueRate", out value) && value is long uniqueRate)
            {
                Data.uniqueRate = (int)uniqueRate;
            }

            if (dataDict.TryGetValue("commonRate", out value) && value is long commonRate)
            {
                Data.commonRate = (int)commonRate;
            }

            if (dataDict.TryGetValue("noProgress", out value) && value is bool noProgress)
            {
                Data.noProgress = noProgress;
            }

            if (dataDict.TryGetValue("lastIndexQuest", out value) && value is long lastIndexQuest)
            {
                Data.lastIndexQuest = (int)lastIndexQuest;
            }

            if (dataDict.TryGetValue("lastFishCounter", out value) && value is long lastFishCounter)
            {
                Data.lastFishCounter = (int)lastFishCounter;
            }

            if (dataDict.TryGetValue("lastNamedFishCounter", out value) && value is long lastNamedFishCounter)
            {
                Data.lastNamedFishCounter = (int)lastNamedFishCounter;
            }

            if (dataDict.TryGetValue("JawaLevel", out value) && value is long jawaLevel)
            {
                Data.JawaLevel = (int)jawaLevel;
            }

            if (dataDict.TryGetValue("SumatraLevel", out value) && value is long sumatraLevel)
            {
                Data.SumatraLevel = (int)sumatraLevel;
            }

            if (dataDict.TryGetValue("KalimantanLevel", out value) && value is long kalimantanLevel)
            {
                Data.KalimantanLevel = (int)kalimantanLevel;
            }

            if (dataDict.TryGetValue("SulawesiLevel", out value) && value is long sulawesiLevel)
            {
                Data.SulawesiLevel = (int)sulawesiLevel;
            }

            if (dataDict.TryGetValue("PapuaLevel", out value) && value is long papuaLevel)
            {
                Data.PapuaLevel = (int)papuaLevel;
            }

            if (dataDict.TryGetValue("lastNamedFish", out value) && value is string lastNamedFish)
            {
                Data.lastNamedFish = lastNamedFish;
            }

            JArray unlockedFishArray;
            if (dataDict.TryGetValue("unlockedFish", out var nilai) && nilai is JArray jArray)
            {
                unlockedFishArray = jArray;
                List<int> unlockedFishList = unlockedFishArray.ToObject<List<int>>();
                Data.unlockedFish = unlockedFishList;
            }
            
        }
        else
        {
            Debug.Log("Data Not Found");
        }
    }
}
