using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtons : MonoBehaviour
{
   public void Replay(){
       //SceneManager.UnloadSceneAsync("SampleScene");
       SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
   }
   public void MainMenu(){
       //SceneManager.UnloadSceneAsync("SampleScene");
       SceneManager.LoadScene("StartMenu");
   }
}
