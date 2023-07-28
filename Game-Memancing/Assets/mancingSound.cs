using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mancingSound : MonoBehaviour
{
    public AudioClip audioTarik;
    public AudioClip audioLempar;
    public AudioSource audioSource;

    public bool tarik;
    public bool lempar;
    
    // Start is called before the first frame update
    void Start()
    {
        if (tarik == true && lempar == false)
        {
            audioSource.clip = audioTarik;
            audioSource.Play();
        }
        else if (tarik == false && lempar == true)
        {
            audioSource.clip = audioLempar;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
