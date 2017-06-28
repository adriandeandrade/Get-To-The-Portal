using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody rBody;
    Camera viewCamera;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        //Look();
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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveInput), 0.15f);
        }

        rBody.MovePosition(rBody.position + moveVelocity * Time.fixedDeltaTime);
    }

    //void Look()
    //{
    //    Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;


    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        Vector3 point = ray.GetPoint(hit.distance);
    //        transform.LookAt(point);
    //    }

}
