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
      SaveLoadData.SaveToJson();
      Application.Quit(); 
   }
   public void koleksi()
   {
      SaveLoadData.SaveToJson();
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
      SaveLoadData.SaveToJson();
      Debug.Log(Data.Tempat);
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
      SaveLoadData.SaveToJson();
      getSceneName();
      SceneManager.LoadScene("Map");
   }
   public void ending()
   {
      SaveLoadData.SaveToJson();
      SceneManager.LoadScene("Ending");
   }
   public void informasi()
   {
      SceneManager.LoadScene("Informasi");
   }
   public void HowToPlay()
   {
      SceneManager.LoadScene("HowToPlay");
   }
   public void back()
   {
      SaveLoadData.SaveToJson();
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
      getSceneName();
      SceneManager.LoadScene("AwalanQuiz");
   }
   public void quiz()
   {
      SaveLoadData.SaveToJson();
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
         case "Quiz":
            SceneManager.LoadScene(Data.Tempat);
            break;
         default:
            Data.lastScene = SceneManager.GetActiveScene().name;
            break;
      }
   }
}
