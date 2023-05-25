using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public List<QuestData> questData;
    public int fishCounter = 0;
    public int namedFishCounter = 0;
    public GameObject misi1;
    public GameObject counter1;
    public GameObject misi2;
    public GameObject counter2;
    public GameObject btnQuiz;
    public int i;

    void Awake()
    {
        i = Random.Range(0,questData.Count);
        Debug.Log(i);
        // masukkan misi ke gameobject
        misi1.GetComponent<Text>().text = questData[i].Misi1;
        misi2.GetComponent<Text>().text = questData[i].Misi2;
        counter1.GetComponent<Text>().text = fishCounter+"/"+questData[i].fishAmount;
        counter2.GetComponent<Text>().text = namedFishCounter+"/"+questData[i].namedFishAmount;
    }
    private void Update()
    {
        counter1.GetComponent<Text>().text = fishCounter+"/"+questData[i].fishAmount;
        counter2.GetComponent<Text>().text = namedFishCounter+"/"+questData[i].namedFishAmount;
    }
}
