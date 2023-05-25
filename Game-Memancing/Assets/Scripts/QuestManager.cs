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
    public CardManager CardManager;
    public int indexQuest;

    void Awake()
    {
        btnQuiz.SetActive(false);
        indexQuest = Random.Range(0,questData.Count);
        Debug.Log(indexQuest);
        // masukkan misi ke gameobject
        misi1.GetComponent<Text>().text = questData[indexQuest].Misi1;
        misi2.GetComponent<Text>().text = questData[indexQuest].Misi2;
        counter1.GetComponent<Text>().text = fishCounter+"/"+questData[indexQuest].fishAmount;
        counter2.GetComponent<Text>().text = namedFishCounter+"/"+questData[indexQuest].namedFishAmount;
    }
    private void Update()
    {
        counter1.GetComponent<Text>().text = fishCounter+"/"+questData[indexQuest].fishAmount;
        counter2.GetComponent<Text>().text = namedFishCounter+"/"+questData[indexQuest].namedFishAmount;
    }
    public void QuestCounter()
    {
        if (fishCounter < questData[indexQuest].fishAmount)
            {
                fishCounter++;
            }

        if (CardManager.cards[Data.indexIkan].nama == "Betutu")
        {
            if (namedFishCounter < questData[indexQuest].namedFishAmount)
            {
                namedFishCounter++;
            }
        }
        if(questData[indexQuest].fishAmount == fishCounter && questData[indexQuest].namedFishAmount == namedFishCounter)
        {
            btnQuiz.SetActive(true);
        }
    }
}
