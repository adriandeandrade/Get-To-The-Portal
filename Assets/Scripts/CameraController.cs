using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        if(FindObjectOfType<PlayerController>() != null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void Update()
    {
        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos + offset, ref velocity, smoothTime);
    }
}
