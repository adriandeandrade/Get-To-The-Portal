using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;

    [HideInInspector] public GameObject player;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 playerSpawnPos;


    private void Start()
    {
        GameOver = false;
        player = Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
    }

    private void Update()
    {
        
    }

    public void EndLevel()
    {
        GameOver = true;
        UIManager.instance.ActivateUI("gameOver");
        if(player != null)
        {
            Destroy(player);
        }
    }

    public void OutOfBounds()
    {
        GameOver = true;
        UIManager.instance.ActivateUI("outOfBounds");
        //player = Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
        player = null;
    }

    public void TryAgain()
    {
        GameOver = false;
        UIManager.instance.DeactivateUI("outOfBounds");
        Reset();
    }

    private void Reset()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        player = null;
    }
}
