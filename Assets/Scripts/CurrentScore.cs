using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private int counter = 0;
    private Text scoreText;

    void Start()
    {
        scoreText=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        counter++;
        if (counter > 9)
        {
            score++;
            scoreText.text = score.ToString();
            counter = 0;
        }
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            Debug.Log("new highscore");
            PlayerPrefs.SetInt("HighScore", score);
        }


    }
}
