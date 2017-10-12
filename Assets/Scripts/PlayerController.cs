using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody rBody;
    Vector3 moveInput;

    public event System.Action OnEnterPortal;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    // Player movement
    void Move()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * speed;
        rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            if (OnEnterPortal != null)
            {
                OnEnterPortal();
            }
        }
    }

    
}
