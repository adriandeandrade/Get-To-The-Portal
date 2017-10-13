using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int currentScore = 0;
    public int highScore;

    public int coinValue = 1;

    public GameObject scoreUI;

    GameObject player;
    string scoreText;

    public void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        player = FindObjectOfType<PlayerController>().gameObject;
        player.GetComponent<PlayerController>().OnCoinPickup += AddScore;
        scoreText = scoreUI.GetComponentInChildren<Text>().text = "SCORE: " + currentScore;
    }

    public void AddScore()
    {
        currentScore += coinValue;
        scoreUI.GetComponentInChildren<Text>().text = "SCORE: " + currentScore;
    }
}
