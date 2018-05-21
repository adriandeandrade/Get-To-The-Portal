using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public ParticleSystem playerExplodeEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ParticleSystem playerEffect = Instantiate(playerExplodeEffect, transform.position, Quaternion.identity); // Make instance of coin effect
            Destroy(playerEffect.gameObject, 2);
            Destroy(other.gameObject);
        }
    }
}
