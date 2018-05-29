using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody rBody;
    Vector3 moveInput;
    Vector3 moveVelocity;

    private GameManager gameManager;
    private ScoreManager scoreManager;
    private Player player;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = gameManager.GetComponent<ScoreManager>();
        player = GetComponent<Player>();
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.GameOver && player.selected)
        {
            Move();
        }
    }

    private void Update()
    {
        if (!GameManager.GameOver)
        {
            CheckBounds();
        }
    }

    private void Move()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        rBody.MovePosition(rBody.position + moveVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            gameManager.EndLevel();
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.Play("PickupCoin");
            scoreManager.IncrementScore();
        }
    }

    private void CheckBounds()
    {
        if (player.isDuplicate)
        {
            if (transform.position.y < 5)
            {
                Destroy(gameObject);
                gameManager.currentSplits = 1;
                gameManager.unitSelection.otherObject = null;
                gameManager.unitSelection.selectedObject = gameManager.unitSelection.originalObject;
                gameManager.unitSelection.selectedObject.GetComponent<Player>().selected = true;
            }
        }
        else
        {
            if(transform.position.y < 5)
            {
                gameManager.OutOfBounds();
            }
        }
    }
}
