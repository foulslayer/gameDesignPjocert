using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    
    private Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    private void Start()
    {
        // Find the player GameObject by tag or name (assuming it's tagged as "Player")
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTransform == null)
        {
            Debug.LogError("Player GameObject not found. Make sure it's tagged as 'Player'.");
        }
    }

    private void Update()
    {
        if (isChasing && playerTransform != null)
        {
            Vector2 playerPosition = playerTransform.position;
            Vector2 currentPosition = transform.position;

            // Calculate the direction to move towards the player
            Vector2 moveDirection = (playerPosition - currentPosition).normalized;

            // Move towards the player in both X and Y axes
            transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (playerTransform != null && Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
                {
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
                {
                    patrolDestination = 0;
                }
            }
        }
    }
}
