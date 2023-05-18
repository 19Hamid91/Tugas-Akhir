using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject movingLine;
    public GameObject area;
    public GameObject resultPanel;
    public GameObject ResultManager;

    float moveArea;
    // Start is called before the first frame update
    void Start()
    {
        Data.direction = -1;
        Data.isInsideArea = false;
        if(Data.Level == 1)
        {
            Data.speed = 3f;
            area.transform.localScale = new Vector3(4, area.transform.localScale.y, area.transform.localScale.z);
        } else if(Data.Level == 2)
        {
            Data.speed = 4f;
            area.transform.localScale = new Vector3(3, area.transform.localScale.y, area.transform.localScale.z);
        } else if(Data.Level == 3)
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

        Data.speed = 0f;
        // play animasi menarik ikan
        Data.indexIkan = Random.Range(0, 10);
        // Debug.Log(Data.indexIkan);
        resultPanel.SetActive(true);

        if (Data.isInsideArea == true)
        {
            // Debug.Log("Anda Dapat Ikan");
            ResultManager.GetComponent<GetResult>().FillResult();
            // menampilkan ikan hasil tangkapan
        }
        else
        {
            // Debug.Log("Ikan Lepas");
            ResultManager.GetComponent<GetResult>().IkanLepas();
            // menampilkan pemeberitahuan gagal
        }
    }

    public void MulaiLagi()
    {
        if(Data.Level == 1)
        {
            Data.speed = 3f;
        } else if(Data.Level == 2)
        {
            Data.speed = 4f;
        } else if(Data.Level == 3)
        {
            Data.speed = 5f;
        }
        moveArea = Random.Range(-2.5f, 2.5f);
        resultPanel.SetActive(false);
        area.transform.position = new Vector3(moveArea, area.transform.position.y, area.transform.position.z);
    }
}
