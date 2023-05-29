using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isMovementAllowed = true;

    public float flashingTime = 0.05f;                  //ennyi ideig hat ez a flash
    private float flashingTimer = 0.0f;
    public bool isFlashing = false;
    public Vector3 movement;

	public enum MovementState 
    {
        idle_front,
        idle_back,
        idle_side,
        walk_front,
        walk_back,
        walk_side
    }

    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isFlashing)
        {
            speed = 15.0f;
            flashingTimer += Time.deltaTime;
            if (flashingTimer >= flashingTime)
            {
                speed = 5.0f;
                flashingTimer = 0;
                isFlashing = false;
            }
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        UpdateAnimationState();
        
        movement = new Vector3(horizontalInput, verticalInput, 0);
		if (isMovementAllowed)
		{
			transform.position += movement * speed * Time.deltaTime;
		}


		transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -25.5f, 25.5f),
            Mathf.Clamp(transform.position.y, -26.5f, 25.5f),
            transform.position.z
        );
    }


	public void StartFlash()
    {
        isFlashing = true;
        flashingTimer = 0;
    }
	private void UpdateAnimationState()
    {
        MovementState state;
        // left
        if (horizontalInput > 0f)
        {
            state = MovementState.walk_side;
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = MovementState.walk_side;
            spriteRenderer.flipX = true;
        }
        else
        {
            if (verticalInput > 0f)
            {
                state = MovementState.walk_back;
            }
            else if (verticalInput < 0f)
            {
                state = MovementState.walk_front;
            }
            else
            {
                state = MovementState.idle_front;
            }
        }
        
        anim.SetInteger("state", (int)state);
    }
}
