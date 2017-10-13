using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public Color teleporterColor;
    public ParticleSystem teleportEffect;
    public Transform interactionBar;

    public bool isTeleporter;

    void Start()
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        rend.material.color = teleporterColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player"))
        {
            interactionBar.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Teleport(other.transform);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player"))
        {
            if (interactionBar.GetComponent<InteractionBar>().isComplete)
            {
                Teleport(other.transform);
                interactionBar.GetComponent<InteractionBar>().currentValue = 0;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player"))
        {
            interactionBar.gameObject.SetActive(false);
        }
    }

    private void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.transform.position = teleportDestinationTarget.transform.position;
    }
}
