using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.125f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (FindObjectOfType<PlayerController>() != null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
    }

    void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
        transform.position = smoothedPos;
        transform.LookAt(target);
    }
}

