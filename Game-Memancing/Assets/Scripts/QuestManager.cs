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
        indexQuest = Random.Range(0,questData.Count);
        getNamedFish();

        if(Data.noProgress == false)
        {
            indexQuest = Data.lastIndexQuest;
            fishCounter = Data.lastFishCounter;
            namedFishCounter = Data.lastNamedFishCounter;
            questData[indexQuest].NamedFish = Data.lastNamedFish;
        }
        
        if(questData[indexQuest].fishAmount == fishCounter && questData[indexQuest].namedFishAmount == namedFishCounter)
        {
            btnQuiz.SetActive(true);
        }
        else
        {
            btnQuiz.SetActive(false);
        }
        
        misi1.GetComponent<Text>().text = questData[indexQuest].Misi1;
        misi2.GetComponent<Text>().text = questData[indexQuest].Misi2+" "+questData[indexQuest].NamedFish;
        counter1.GetComponent<Text>().text = fishCounter+"/"+questData[indexQuest].fishAmount;
        counter2.GetComponent<Text>().text = namedFishCounter+"/"+questData[indexQuest].namedFishAmount;

        // save to data
        Data.lastIndexQuest = indexQuest;
        Data.lastNamedFish = questData[indexQuest].NamedFish;
        Data.noProgress = false;
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

        if (CardManager.cards[Data.indexIkan].nama == questData[indexQuest].NamedFish)
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

        // save to data
        Data.lastFishCounter = fishCounter;
        Data.lastNamedFishCounter = namedFishCounter;
    }

    private void getNamedFish()
    {
        if(Data.Level != 3)
        {
            questData[indexQuest].NamedFish = CardManager.cards[Random.Range(0,CardManager.cards.Count - 2)].nama;
        }
        else
        {
            questData[indexQuest].NamedFish = CardManager.cards[Random.Range(CardManager.cards.Count - 2,CardManager.cards.Count)].nama;
        }
    }

    // private void getDataFromLocal()
    // {
    //     // mengambil data misi dari local
    // }
}
