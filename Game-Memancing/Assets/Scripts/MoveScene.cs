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
   public void keluar()
   {
      Application.Quit(); 
   }
   public void koleksi()
   {
      getSceneName();
      SceneManager.LoadScene("Koleksi");
   }
   public void mainMenu()
   {
      getSceneName();
      SceneManager.LoadScene("MainMenu");
   }
   public void Deskripsi(int index)
   {
      getSceneName();
      SceneManager.LoadScene("Deskripsi");
      Data.indexIkan = index;
   }
   public void gameplay()
   {
      getSceneName();
      SceneManager.LoadScene(Data.Tempat);
   }
   public void level()
   {
      getSceneName();
      SceneManager.LoadScene("Level");
   }
   public void map()
   {
      getSceneName();
      SceneManager.LoadScene("Map");
   }
   public void back()
   {
      if (Data.lastScene != null)
      {
         SceneManager.LoadScene(Data.lastScene);
      }
      else
      {
         SceneManager.LoadScene("Map");
      }
   }
   public void awalanQuiz()
   {
      SceneManager.LoadScene("AwalanQuiz");
   }
   public void quiz()
   {
      SceneManager.LoadScene("Quiz");
   }

   private void getSceneName()
   {
      switch (SceneManager.GetActiveScene().name)
      {
         case "Deskripsi":
            break;
         case "Story":
            break;
         case "Koleksi":
            break;
         default:
            Data.lastScene = SceneManager.GetActiveScene().name;
            break;
      }
   }
}
