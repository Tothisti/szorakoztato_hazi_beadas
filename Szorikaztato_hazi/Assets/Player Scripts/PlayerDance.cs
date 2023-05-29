using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDance : MonoBehaviour
{
    public float moveSpeed = 25.0f;

	public float directionChangeTime = 0.05f;
	private float directionChangeTimer = 0.0f;

	private Vector2 currentRandomDirection;
    public float danceTime = 1.5f;                  //ennyi ideig hat ez a dance :)
    private float danceTimer = 0.0f;
    private bool isDancing = false;
	public TextMeshProUGUI DanceText;

	// Start is called before the first frame update
	void Start()
    {

    }

	// Update is called once per frame
	void Update()
	{
		if (isDancing)
		{
			DanceText.text = "Dancing";
			danceTimer += Time.deltaTime;
			if (danceTimer >= danceTime)
			{
				PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
				playerMovement.isMovementAllowed = true;
				danceTimer = 0;
				isDancing = false;
			}
			else
			{
				directionChangeTimer += Time.deltaTime;
				if (directionChangeTimer >= directionChangeTime)
				{
					directionChangeTimer = 0;
					currentRandomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
				}
				transform.position += (Vector3)currentRandomDirection * moveSpeed * (Time.deltaTime * 2.0f);
			}
		}
		else
		{
			DanceText.text = "";
		}
	}
	public void StartDancing()
    {
        Player playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (!playerComponent.isProtected)
        {
            if (playerComponent.haveCape)
            {
                int randomNumber = Random.Range(0, 101);
                if (randomNumber > 18)
                {
                    playerMovement.isMovementAllowed = false;
                    isDancing = true;
                    danceTimer = 0;
                }
            }
            else
            {
                playerMovement.isMovementAllowed = false;
                isDancing = true;
                danceTimer = 0;
            }
        }
    }
}
