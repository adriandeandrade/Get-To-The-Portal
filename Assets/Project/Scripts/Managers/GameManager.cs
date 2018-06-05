using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;

    public bool isSplit = false;

    [HideInInspector] public GameObject player;
    public GameObject playerPrefab;

    public UnitSelection unitSelection;
    public CameraController cameraController;

    [SerializeField] private Vector3 playerSpawnPos;

    private void Awake()
    {
        unitSelection = FindObjectOfType<UnitSelection>();
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Start()
    {
        GameOver = false;
        player = Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
        player.GetComponent<Player>().selected = true;
        unitSelection.selectedObject = player;
        unitSelection.originalObject = player;
    }

    public void EndLevel()
    {
        GameOver = true;
        UIManager.instance.ActivateUI("gameOver");
        if (player != null)
        {
            Destroy(player);
        }
    }

    public void OutOfBounds()
    {
        GameOver = true;
        UIManager.instance.ActivateUI("outOfBounds");
        player = null;
    }

    public void TryAgain()
    {
        GameOver = false;
        UIManager.instance.DeactivateUI("outOfBounds");
        ResetCurrentLevel();
    }

    private void ResetCurrentLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        player = null;
    }
}
