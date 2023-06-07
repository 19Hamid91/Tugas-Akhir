using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject movingLine;
    public GameObject area;
    public GameObject resultPanel;
    public GetResult ResultManager;
    public QuestManager QuestManager;
    public CardManager CardManager;
    public Animator Pina;

    float moveArea;
    // Start is called before the first frame update
    void Start()
    {
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
        switch (Data.Level)
        {
            case 3:
                Data.uniqueRate = 10;
                break;
            case 2:
                Data.uniqueRate = 20;
                break;
            default:
                Data.uniqueRate = 30;
                break;
        }
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
        }
        else
        {
            // Debug.Log("Ikan Lepas");
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
    }

    IEnumerator playAnimasi()
    {
        Data.speed = 0f;
        Pina.SetTrigger("Tangkap");
        yield return new WaitForSeconds(2);
        TangkapIkan();
    }

    public void Tangkap()
    {
        StartCoroutine(playAnimasi());
    }
}
