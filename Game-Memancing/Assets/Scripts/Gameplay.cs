using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject movingLine;
    // Start is called before the first frame update
    void Start()
    {
        Data.direction = -1;
        Data.speed = 3f;
        Data.isInsideArea = false;
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

        if (Data.isInsideArea == true)
        {
            Debug.Log("Anda Dapat Ikan");
            // menampilkan ikan hasil tangkapan
        }
        else
        {
            Debug.Log("Ikan Lepas");
            // menampilkan pemeberitahuan gagal
        }
    }

    public void MulaiLagi()
    {
        Data.speed = 3f;
    }
}
