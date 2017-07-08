using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public bool isTeleporter;
    public Color teleporterColor;
    public ParticleSystem teleportEffect;

    private void Start()
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        rend.material.color = teleporterColor;
    }

    public void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.position = teleportDestinationTarget.position;
    }
}
