using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
   public GameObject skip;
   public float timer;
     void Start()
     {
         StartCoroutine(Show(timer));
     }
     IEnumerator Show(float delay)
     {
         yield return new WaitForSeconds(delay);
         skip.SetActive(true);
     }
}
