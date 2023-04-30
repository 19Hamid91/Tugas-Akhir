using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
   public void nextScene()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void prevScene()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }
   public void koleksi()
   {
    SceneManager.LoadScene("Koleksi");
   }
   public void mainMenu()
   {
    SceneManager.LoadScene("MainMenu");
   }
}
