using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool selected = false;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Split();
        }
    }

    private void Split()
    {
        if (gameManager.currentSplits < gameManager.maxSplits)
        {
            Vector3 spawnPos = FindSplitPosition();
            GameObject split = Instantiate(gameManager.playerPrefab, spawnPos, Quaternion.identity);
            gameManager.unitSelection.otherObject = split;
            gameManager.currentSplits++;
        }
        else
        {
            Debug.LogError("Max amount of splits reached.");
        }
    }

    private void DeselectOtherPlayers()
    {
        selected = false;
    }

    private Vector3 FindSplitPosition()
    {
        Vector3 spawnPos = transform.position + (Vector3.left * 0.5f);
        return spawnPos;
    }
}
