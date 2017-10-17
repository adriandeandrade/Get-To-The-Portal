using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public GameObject interactionBar;

    public bool isTeleporter;

    void OnTriggerEnter(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player"))
        {
            interactionBar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player")) // Check if the player is standing on the teleporter.
        {
            interactionBar.SetActive(false); // Disable the interaction bar when player steps off teleporter.

        }
    }

    void OnTriggerStay(Collider other)
    {
        // This is where the actual teleport happens
        if (isTeleporter && other.gameObject.CompareTag("Player")) // Check if we are indeed standing on a teleporter, not a destination.
        {
            if (interactionBar.GetComponent<InteractionBar>().isComplete) // Check to see if the progress bar is full.
            {
                Teleport(other.transform); // Teleport the player
                interactionBar.GetComponent<InteractionBar>().currentValue = 0; // Set the progress bar back to 0.
            }
        }
    }

    private void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.transform.position = teleportDestinationTarget.transform.position; // Teleport
    }
}
