using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;
    public GameObject levelCompleteUI;

    void Start()
    {
        GameOver = false;
    }

    public void EndLevel()
    {
        GameOver = true;
        levelCompleteUI.SetActive(true);
    }
}
