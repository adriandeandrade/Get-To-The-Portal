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

    //public void Teleport(Transform objectToTeleport)
    //{
        
    //}

    public IEnumerator Teleport(Transform objectToTeleport, float teleportDelay)
    {
        yield return new WaitForSeconds(teleportDelay);

        objectToTeleport.position = teleportDestinationTarget.position;
        Destroy(Instantiate(teleportEffect, objectToTeleport.position, Quaternion.identity), 1);
    }
}
