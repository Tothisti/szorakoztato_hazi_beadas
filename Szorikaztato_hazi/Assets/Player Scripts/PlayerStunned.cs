using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStunned : MonoBehaviour
{
    public float stunnedTime = 2.0f;                  //ennyi ideig hat ez a stun :)
    private float stunnedTimer = 0.0f;
    private bool isStunned = false;
	public TextMeshProUGUI StunnedText;
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned)
        {
			StunnedText.text = "Stunned";
			PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            playerMovement.isMovementAllowed = false;
            stunnedTimer += Time.deltaTime;
            if (stunnedTimer >= stunnedTime)
            {
                stunnedTimer = 0;
                isStunned = false;
                playerMovement.isMovementAllowed = true;
            }
        }
        else
        {
            StunnedText.text = "";
        }
    }
    public void StartStunned()
    {
        Player playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!playerComponent.isProtected)
        {
            if (playerComponent.haveCape)
            {
                int randomNumber = Random.Range(0, 101);
                if(randomNumber > 82)
                {
                    isStunned = true;
                    stunnedTimer = 0;
                }
            }
            else
            {
                isStunned = true;
                stunnedTimer = 0;
            }
        }
    }
}
