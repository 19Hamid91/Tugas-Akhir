using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public GameObject movingLine;
    public GameObject area;
    public GameObject disabler;
    public GameObject resultPanel;
    public GameObject nyawaHabisPanel;
    public GetResult ResultManager;
    public QuestManager QuestManager;
    public CardManager CardManager;
    public Animator Pina;
    public Text Nyawa;

    float moveArea;
    string tempat;
    int questProgress;
    // Start is called before the first frame update
    void Start()
    {
        Data.nyawaCounter = 3;
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

        if(questProgress > Data.Level)
        {
            Nyawa.text = "-";
        }
        else
        {
            Nyawa.text = ""+Data.nyawaCounter;
        }
        nyawaHabisPanel.SetActive(false);
        resultPanel.SetActive(false);
        disabler.SetActive(false);
        if (Data.Tempat == "GamePlayKalimantan")
        {
            tempat = "Kalimantan";
        }
        else if(Data.Tempat == "GamePlaySumatra")
        {
            tempat = "Sumatra";
        }
        else if(Data.Tempat == "GamePlaySulawesi")
        {
            tempat = "Sulawesi";
        }
        else if(Data.Tempat == "GamePlayPapua")
        {
            tempat = "Papua";
        }
        else
        {
            tempat = "Jawa";
        }
        Data.direction = -1;
        Data.isInsideArea = false;
        if(Data.Level == 2)
        {
            Data.speed = 6f;
            area.transform.localScale = new Vector3(1.5f, area.transform.localScale.y, area.transform.localScale.z);
        } else if(Data.Level == 3)
        {
            Data.speed = 7f;
            area.transform.localScale = new Vector3(1, area.transform.localScale.y, area.transform.localScale.z);
        } else
        {
            Data.speed = 5f;
            area.transform.localScale = new Vector3(2, area.transform.localScale.y, area.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Data.speed != 0f)
        {
		    movingLine.transform.Translate(Data.direction * Time.deltaTime * Data.speed, 0, 0);
        }
        return;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag.Equals("Area"))
        {
            // Debug.Log("Didalam area");
            Data.isInsideArea = true;
        }       
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Data.isInsideArea = false;       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
    if (col.transform.tag.Equals("RightLimit"))
        {
            Data.direction = -1;
        }
    if (col.transform.tag.Equals("LeftLimit"))
        {
            Data.direction = 1;
        }
    }

    public void TangkapIkan()
    {
        Data.uniqueRate = 20; 
        Data.commonRate = 100 - Data.uniqueRate;
        
        // play animasi menarik ikan
        resultPanel.SetActive(true);

        if (Data.isInsideArea == true)
        {
            if (Data.Level == 3)
            {
                var diceroll = Random.Range(1,100);
                if (Data.commonRate >= diceroll)
                {
                    // dapat ikan biasa
                    Data.indexIkan = Random.Range(0,CardManager.cards.Count - 2);
                    Debug.Log("Ikan Biasa");
                }
                else
                {
                    // dapat ikan langka
                    Data.indexIkan = Random.Range(CardManager.cards.Count - 4,CardManager.cards.Count);
                    Debug.Log(Data.indexIkan);
                }
            }
            else if(Data.Level == 2)
            {
                Data.indexIkan = Random.Range(0,CardManager.cards.Count - 2);
                Debug.Log("0-4");
            }
            else
            {
                Data.indexIkan = Random.Range(0,CardManager.cards.Count - 4);
                Debug.Log("0-2");
            }
                
            
            if(!Data.unlockedFish.Contains(CardManager.cards[Data.indexIkan].idIkan))
            {
                Data.unlockedFish.Add(CardManager.cards[Data.indexIkan].idIkan);
            }
            QuestManager.QuestCounter();
            ResultManager.FillResult();
            SaveLoadData.SaveToJson();
        }
        else
        {
            if(questProgress <= Data.Level)
            {
                Data.nyawaCounter--;
                Nyawa.text = ""+Data.nyawaCounter;
                if (Data.nyawaCounter == 0)
                {
                    nyawaHabisPanel.SetActive(true);
                }
            }
            Debug.Log("Ikan Lepas");
            ResultManager.IkanLepas();
        }
    }

    public void MulaiLagi()
    {

        Pina.SetTrigger("Lempar");
        if(Data.Level == 2)
        {
            Data.speed = 6f;
        } else if(Data.Level == 3)
        {
            Data.speed = 7f;
        } else
        {
            Data.speed = 5f;
        }
        moveArea = Random.Range(-2.5f, 2.5f);
        resultPanel.SetActive(false);
        area.transform.position = new Vector3(moveArea, area.transform.position.y, area.transform.position.z);
        disabler.SetActive(false);
    }

    IEnumerator playAnimasi()
    {
        Data.speed = 0f;
        Pina.SetTrigger(tempat);
        yield return new WaitForSeconds(2);
        TangkapIkan();
    }

    public void Tangkap()
    {
        disabler.SetActive(true);
        StartCoroutine(playAnimasi());
    }

    public void resetNyawa()
    {
        Data.nyawaCounter = 3;
        QuestManager.getNewQuest();
        Nyawa.text = ""+Data.nyawaCounter;
        nyawaHabisPanel.SetActive(false);
        MulaiLagi();
    }
}
