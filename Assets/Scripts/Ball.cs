using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float xRange;

    Vector2 moveDirection;

    void Start() 
    {
        moveDirection = Vector2.left;    
    }

    void Update()
    {
        Move();
        GetInput();

        if(transform.position.x <= -xRange || transform.position.x >= xRange)
        {
            moveDirection *= -1;
        }
    }

    void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            moveDirection *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Score"))
        {
            GameManager.Instance.IncreaseScore();
            moveSpeed *= 1.0075f;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameManager.Instance.ResetGame();
        }
    }

}
