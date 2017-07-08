using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float distanceToCollision = 3f;
    public WorldSpaceUI worldSpaceUI;

    Rigidbody rBody;
    Vector3 moveInput;


    public event System.Action OnEnterPortal;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        IsColliding();
    }

    void Move()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector3.zero)
        {
            rBody.rotation = Quaternion.LookRotation(moveInput);
        }

        if (!IsColliding())
        {
            rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            if (OnEnterPortal != null)
            {
                OnEnterPortal();
            }
        }
    }

    private void OnTriggerStay(Collider other)
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

    bool IsColliding()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, forward, out hit, distanceToCollision))
        {
            if (hit.collider.tag == "Obstacle")
            {
                print("Object was hit");
                return true;
            }
        }
        return false;
    }
}
