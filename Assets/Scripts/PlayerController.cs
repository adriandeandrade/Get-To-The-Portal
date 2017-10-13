using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody rBody;
    Vector3 moveInput;
    Vector3 moveVelocity;

    bool gameOver = false;

    public event System.Action OnEnterPortal;
    public event System.Action OnCoinPickup;

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
        if (!gameOver)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            gameOver = true;
            if (OnEnterPortal != null)
            {
                OnEnterPortal();
            }
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.Play("PickupCoin");
            //FindObjectOfType<AudioManager>().Play("PickupCoin");
            if (OnCoinPickup != null)
            {
                OnCoinPickup();
            }
        }
    }


}
