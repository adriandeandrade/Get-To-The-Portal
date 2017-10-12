using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float distanceToCollision = 3f;
    public WorldSpaceUI worldSpaceUI;

    bool isStandingOnTeleporter = false;

    Rigidbody rBody;
    Vector3 moveInput;

    public event System.Action OnEnterPortal;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        isStandingOnTeleporter = false;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * speed;
        rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);
    }

    public bool IsStandingOnTeleporter()
    {
        if (isStandingOnTeleporter)
        {
            return true;
        }
        else
        {
            return false;
        }
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
        {
            worldSpaceUI.SetTextContentAndPosition("Press E To Teleport", other.transform.position, other.gameObject);
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Teleporter>().Teleport(transform);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Obstacle")
        {
            moveInput = Vector3.zero;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
        {
            worldSpaceUI.DisableUI();
        }
    }
}
