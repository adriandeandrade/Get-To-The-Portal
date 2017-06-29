using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody rBody;
    Vector3 moveInput;

    // Event to keep track of when player enters a portal
    public event System.Action OnEnterPortal;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Get the player input
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // Get direction and times it by speed var to move in corresponding direction
        Vector3 moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector3.zero)
        {
            // Rotate player to face direction we are moving in, only when we are actually moving
            rBody.rotation = Quaternion.LookRotation(moveInput);
        }

        // Move player
        rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if player is touching a teleporter
        if(other.gameObject.tag == "Teleporter")
        {
            // Teleport player
            StartCoroutine(other.GetComponent<Teleporter>().Teleport(transform, 2f));
        }
        // Check if player is touching a portal
        if(other.gameObject.tag == "Portal")
        {
            // End level if is the player is touching a portal
            if(OnEnterPortal != null)
            {
                OnEnterPortal();
            }
        }
    }
}
