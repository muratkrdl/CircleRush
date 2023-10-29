using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float minMoveSpeed = 1f;
    [SerializeField] float maxMoveSpeed = 5f;

    [SerializeField] float directionRange = .5f;

    Ball playerBall;
    Transform player;

    float moveSpeed = 5f;

    float increaseX;
    float increaseY;
    Vector2 moveDirection;

    void Start() 
    {
        playerBall = FindObjectOfType<Ball>();
        if(playerBall != null)
        {
            player = playerBall.transform;
        }
        else
        {
            if(player == null) { return; }
            player.position = Vector2.up;
        }
        increaseX = Random.Range(-directionRange, directionRange);
        increaseY = Random.Range(-directionRange,directionRange);
        moveDirection = (-new Vector2(transform.position.x - player.position.x + increaseX, transform.position.y - player.position.y + increaseY)).normalized;
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        Destroy(gameObject,10);
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

}

