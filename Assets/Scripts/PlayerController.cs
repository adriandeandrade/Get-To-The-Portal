using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody rBody;

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
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector3.zero)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveInput), 0.15f);
            rBody.MoveRotation(Quaternion.Slerp(rBody.rotation, Quaternion.LookRotation(moveInput), 0.15f));
        }

        rBody.MovePosition(rBody.position + moveVelocity * Time.fixedDeltaTime);
        //rBody.MoveRotation
    }


}
