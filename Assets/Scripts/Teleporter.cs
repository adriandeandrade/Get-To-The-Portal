using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public bool isTeleporter;
    public Color teleporterColor;
    public ParticleSystem teleportEffect;

    public WorldSpaceUIManager worldSpaceUI;

    void Start()
    {
        Renderer rend = GetComponentInChildren<Renderer>();
        rend.material.color = teleporterColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Collided with teleporter");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isTeleporter)
        {
            if (other.gameObject.tag == "Player")
            {
                worldSpaceUI.SetTextContentAndPosition("Press E To Teleport", other.transform.position, other.gameObject);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Teleport(other.transform);
                }
            }
        }
    }

    private void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.transform.position = teleportDestinationTarget.transform.position;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            worldSpaceUI.DisableUI();
        }
    }
}
