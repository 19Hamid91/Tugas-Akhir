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
    public GameObject completed;
    public CardManager CardManager;
    public int indexQuest;
    public int questProgress;

    void Awake()
    {
        indexQuest = Random.Range(0,questData.Count);
         if (Data.Tempat == "GamePlayJawa")
            {
                questProgress = Data.JawaLevel;
            }
        else if (Data.Tempat == "GamePlaySumatra")
            {
                questProgress = Data.SumatraLevel;
            }
        else if (Data.Tempat == "GamePlayKalimantan")
            {
                questProgress = Data.KalimantanLevel;
            }
        else if (Data.Tempat == "GamePlaySulawesi")
            {
                questProgress = Data.SulawesiLevel;
            }
        else if (Data.Tempat == "GamePlayPapua")
            {
                questProgress = Data.PapuaLevel;
            }
        getNamedFish();

        if(questProgress > Data.Level)
        {
            questData[indexQuest].fishAmount = questData[indexQuest].fishAmount;
            questData[indexQuest].namedFishAmount = questData[indexQuest].namedFishAmount;
            completed.SetActive(true);
            btnQuiz.SetActive(false);
            misi1.SetActive(false);
            misi2.SetActive(false);
            counter1.SetActive(false);
            counter2.SetActive(false);
        }
        else if(Data.noProgress == false)
        {
            // Debug.Log("test");
            indexQuest = Data.lastIndexQuest;
            fishCounter = Data.lastFishCounter;
            namedFishCounter = Data.lastNamedFishCounter;
            questData[indexQuest].NamedFish = Data.lastNamedFish;
        }
        
        if(fishCounter >= questData[indexQuest].fishAmount && namedFishCounter >= questData[indexQuest].namedFishAmount)
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
        if (Data.Level >= questProgress)
        {
            Data.lastIndexQuest = indexQuest;
            Data.lastNamedFish = questData[indexQuest].NamedFish;
        }
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
       if(fishCounter >= questData[indexQuest].fishAmount && namedFishCounter >= questData[indexQuest].namedFishAmount)
        {
            if(questProgress <= Data.Level)
            {
                btnQuiz.SetActive(true);
            }
        }

        // save to data
        if (Data.Level >= questProgress)
        {
            Data.lastFishCounter = fishCounter;
            Data.lastNamedFishCounter = namedFishCounter;
            Data.noProgress = false;
        }
    }

    private void getNamedFish()
    {
        if(Data.Level == 3)
        {
            questData[indexQuest].NamedFish = CardManager.cards[Random.Range(CardManager.cards.Count - 2,CardManager.cards.Count)].nama;
            
        }
        else if(Data.Level == 2)
        {
           questData[indexQuest].NamedFish = CardManager.cards[Random.Range(0,CardManager.cards.Count - 2)].nama;
        }
        else
        {
            questData[indexQuest].NamedFish = CardManager.cards[Random.Range(0,CardManager.cards.Count - 4)].nama;
        }
    }

    public void getNewQuest()
    {
        indexQuest = Random.Range(0,questData.Count);
        getNamedFish();
        fishCounter = 0;
        namedFishCounter = 0;
        btnQuiz.SetActive(false);
        misi1.GetComponent<Text>().text = questData[indexQuest].Misi1;
        misi2.GetComponent<Text>().text = questData[indexQuest].Misi2+" "+questData[indexQuest].NamedFish;
        counter1.GetComponent<Text>().text = fishCounter+"/"+questData[indexQuest].fishAmount;
        counter2.GetComponent<Text>().text = namedFishCounter+"/"+questData[indexQuest].namedFishAmount;
        if (Data.Level >= questProgress)
        {
            Data.lastFishCounter = fishCounter;
            Data.lastNamedFishCounter = namedFishCounter;
            Data.noProgress = false;
            Data.lastIndexQuest = indexQuest;
            Data.lastNamedFish = questData[indexQuest].NamedFish;
        }
    }
}
