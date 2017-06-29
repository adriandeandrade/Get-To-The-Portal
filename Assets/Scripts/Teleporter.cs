using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public bool isTeleporter;
    public Color teleporterColor;

    private void Start()
    {
        Renderer rend = GameObject.Find("TeleporterModel").GetComponent<Renderer>();
        rend.material.SetColor("Teleporter", teleporterColor);
    }

    public void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.position = teleportDestinationTarget.position;
    }
}
