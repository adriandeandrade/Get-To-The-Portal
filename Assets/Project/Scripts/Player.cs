using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool selected = false;
    public bool isClone;

    private GameManager gameManager;
    private UnitSelection unitSelection;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        unitSelection = gameManager.unitSelection;

        if(!isClone)
        {
            unitSelection.playerObjects.Add(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Split();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UnSplit();
            Debug.Log("Unsplit");
        }
    }

    private void Split()
    {
        if (!gameManager.isSplit)
        {
            gameManager.isSplit = true;
            InitalizeSplit();
        }
        else
        {
            Debug.LogError("Max amount of splits reached.");
        }
    }

    private void UnSplit()
    {
        if (gameManager.isSplit)
        {
            foreach (GameObject pObject in unitSelection.playerObjects)
            {
                if (pObject.GetComponent<Player>().isClone)
                {
                    Destroy(pObject.gameObject);
                    unitSelection.playerObjects.Clear();
                    unitSelection.playerObjects.Add(unitSelection.originalObject);
                    unitSelection.selectedObject = unitSelection.originalObject;
                    unitSelection.originalObject.GetComponent<Player>().selected = true;
                    unitSelection.otherObject = null;
                    unitSelection.originalObject.transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
                    gameManager.isSplit = false;
                    return;
                }
            }
        }
    }

    private void InitalizeSplit()
    {
        Vector3 spawnPos = FindSplitPosition();
        GameObject split = Instantiate(gameManager.playerPrefab, spawnPos, Quaternion.identity);
        split.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2); // Split the clones size
        split.name = "player dup";
        split.GetComponent<Player>().isClone = true;
        unitSelection.playerObjects.Add(split);

        unitSelection.otherObject = split;
        unitSelection.originalObject.transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2); // Split the original objects size.
    }

    private Vector3 FindSplitPosition()
    {
        Vector3 spawnPos = transform.position + (Vector3.left * 0.5f);
        return spawnPos;
    }
}
