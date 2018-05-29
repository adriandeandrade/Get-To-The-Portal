using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        GetTarget();
    }
    
    public void GetTarget()
    {
        target = gameManager.unitSelection.selectedObject.transform;
    }

    void FixedUpdate()
    {
        

        if (GameManager.GameOver) return;
        GetTarget();
        if (target != null)
        {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
            transform.position = smoothedPos;
            transform.LookAt(target);
        }
    }
}

