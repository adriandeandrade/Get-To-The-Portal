using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportDestinationTarget;
    public bool isTeleporter;

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("collided");
    //    if (isTeleporter)
    //    {
    //        if (other.gameObject.tag == "Player")
    //        {
                
    //            other.transform.position = teleportDestinationTarget.position;
    //        }
    //    }
    //}

    public void Teleport(Transform objectToTeleport)
    {
        objectToTeleport.position = teleportDestinationTarget.position;
    }
}
