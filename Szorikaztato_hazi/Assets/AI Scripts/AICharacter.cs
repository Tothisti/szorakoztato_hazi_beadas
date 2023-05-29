using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    private bool isMovementAllowed = true;

    public float followDistance = 9.0f;
    public float moveSpeed = 4.5f;

    public float idleTime = 1.0f;
    public float idleTimer = 0.0f;

    public float wanderTime = 2.0f;
    private float wanderTimer = 0.0f;

    public float danceTime = 5.0f;
    private float danceTimer = 0.0f;
    private bool isDancing = false;

    public float stunnedTime = 5.0f;
    public float stunnedTimer = 0.0f;
    private bool isStunned = false;

    public float flashingTime = 1.0f;
    public float flashingTimer = 0.0f;
    private bool isFlashing = false;

    private int wanderTowardsPlayer = 0;

	private enum AIState { Idle, Wandering };
    private AIState currentState = AIState.Idle;

    private Vector2 currentRandomDirection;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void StartFlashing()
    {
        isFlashing = true;
        flashingTimer = 0;
    }
    public void StartDancing()
    {
        isDancing = true;
        danceTimer = 0;
    }
    public void StartStunning()
    {
        isStunned = true;
        stunnedTimer = 0;
    }
    private void Update()
    {
        if (!isDancing && !isStunned && isFlashing)
        {
            moveSpeed = 7.0f;
            flashingTimer += Time.deltaTime;
            if (flashingTimer >= flashingTime)
            {
                moveSpeed = 5.0f;
                flashingTimer = 0;
                isFlashing = false;
            }
        }
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (isStunned)
        {
            isMovementAllowed = false;
            stunnedTimer += Time.deltaTime;
            if (stunnedTimer >= stunnedTime)
            {
                stunnedTimer = 0;
                isStunned = false;
                isMovementAllowed = true;
            }
        }
        else if (isDancing && !isStunned)
        {
            if (isMovementAllowed)
            {
                danceTimer += Time.deltaTime;
                if (danceTimer >= danceTime)
                {
                    danceTimer = 0;
                    isDancing = false;
                }
                else
                {
                    RandomMove();
                }
            }
        }
        else if (distance < followDistance && isDancing == false)
        {
            if (isMovementAllowed)
            {
                currentState = AIState.Idle;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (isMovementAllowed)
            {
                RandomMove();
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -25.5f, 25.5f),
            Mathf.Clamp(transform.position.y, -26.5f, 25.5f),
            transform.position.z
        );
    }
	public void RandomMove()
	{
		switch (currentState)
		{
			case AIState.Idle:
				idleTimer += Time.deltaTime;
				if (idleTimer >= idleTime)
				{
					idleTimer = 0;
					currentState = AIState.Wandering;
					currentRandomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                    if(wanderTowardsPlayer == 4)
                    {
                        wanderTowardsPlayer = 0;
					}
                    wanderTowardsPlayer++;
				}
				break;

			case AIState.Wandering:
				wanderTimer += Time.deltaTime;
				if (wanderTimer >= wanderTime)
				{
					wanderTimer = 0;
					currentState = AIState.Idle;
				}
				else
				{
                    if(wanderTowardsPlayer == 4)
                    {
                        // Debug.Log("Feledmegyek");
						Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
					}
					else
                    {
    					transform.position += (Vector3)currentRandomDirection * moveSpeed * Time.deltaTime;
                    }
				}
				break;
		}
	}
}