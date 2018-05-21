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
        GetTarget();
    }
    
    public void GetTarget()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    void FixedUpdate()
    {
        if (GameManager.GameOver) return;
        if (target != null)
        {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
            transform.position = smoothedPos;
            transform.LookAt(target);
        }
    }
}

