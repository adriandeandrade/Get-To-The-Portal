using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int currentScore = 0;
    //public int highScore;

    public int coinValue = 1;

    public GameObject scoreUI;

    Text scoreText;

    GameObject player;

    public void Start()
    {
        //highScore = PlayerPrefs.GetInt("Highscore");
        scoreText = scoreUI.GetComponentInChildren<Text>();
    }

    public void IncrementScore()
    {
        currentScore += coinValue;
        scoreText.text = "SCORE: " + currentScore;
    }
}
