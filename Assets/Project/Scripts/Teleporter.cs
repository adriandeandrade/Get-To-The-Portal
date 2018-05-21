using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public GameObject interactionBar;

    new ParticleSystem particleSystem;
    ParticleSystem.MainModule particleSystemMainModule;

    [SerializeField]
    private bool isTeleporter;

    void Start()
    {
        Transform ringParticle = transform.GetChild(1); // Get the ring particle system in the teleporter instance
        particleSystem = ringParticle.GetComponent<ParticleSystem>();
        particleSystemMainModule = particleSystem.main;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player"))
        {
            particleSystemMainModule.startColor = Color.red;
            interactionBar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isTeleporter && other.gameObject.CompareTag("Player")) // Check if the player is standing on the teleporter.
        {
            particleSystemMainModule.startColor = Color.white;
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
