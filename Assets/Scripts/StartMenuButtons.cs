using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void resetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
