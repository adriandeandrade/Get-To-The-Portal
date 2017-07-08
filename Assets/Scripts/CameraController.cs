using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        if (FindObjectOfType<PlayerController>() != null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void Update()
    {
        target = target = FindObjectOfType<PlayerController>().transform;
    }

    public Vector3 GetCameraOffset()
    {
        return offset;
    }

    private void LateUpdate()
    {

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothTime);
        transform.LookAt(target);
        transform.position = smoothedPos;

    }
}

