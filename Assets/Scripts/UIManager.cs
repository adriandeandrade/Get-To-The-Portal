using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject levelCompleteUI;

    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        player.GetComponent<PlayerController>().OnEnterPortal += EndLevelUI;
    }

    public void EndLevelUI()
    {
        levelCompleteUI.SetActive(true);
    }
}
