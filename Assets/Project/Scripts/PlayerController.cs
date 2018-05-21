using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isActivePlayer;
    public float speed;

    Rigidbody rBody;
    Vector3 moveInput;
    Vector3 moveVelocity;

    private GameManager gameManager;
    private ScoreManager scoreManager;

    public GameObject playerPrefab;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = gameManager.GetComponent<ScoreManager>();
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        CheckOutOfBounds();
    }

    private void Move()
    {
        if (!GameManager.GameOver)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            gameManager.EndLevel();
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.Play("PickupCoin");
            scoreManager.IncrementScore();
        }
    }

    private void CheckOutOfBounds()
    {
        if(!GameManager.GameOver)
        {
            if(transform.position.y < 5)
            {
                gameManager.OutOfBounds();
            }
        }
    } 


}
