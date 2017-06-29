using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.125f;
    public Vector3 offset;

    //private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        if (FindObjectOfType<PlayerController>() != null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothTime);
        transform.position = smoothedPos;
        transform.LookAt(target);
    }

    //private void FixedUpdate()
    //{
    //    Vector3 goalPos = target.position;
    //    goalPos.y = transform.position.y;
    //    transform.position = Vector3.SmoothDamp(transform.position, goalPos + offset, ref velocity, smoothTime);
    //}
}
