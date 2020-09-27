using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void resetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
