using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public ParticleSystem coinPickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ParticleSystem coinEffect = Instantiate(coinPickupEffect, transform.position, Quaternion.identity); // Make instance of coin effect
            Destroy(coinEffect.gameObject, 2);
            Destroy(gameObject);
        }
    }
}
