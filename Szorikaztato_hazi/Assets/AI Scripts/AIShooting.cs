using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    private bool ableToStun = false;
    private float stunningTimer = 0.0f;
    private float stunningTime = 10.0f;

    private bool ableToDance = false;
    private float dancingTimer = 0.0f;
    private float dancingTime = 7.0f;
    void Start()
    {
        InvokeRepeating("Flashing", 0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 7.5f)
        {
            ableToStun = true;
        }
        if(distance < 20.0f)
        {
			ableToDance = true;
		}
		if (ableToStun)
        {
            stunningTimer += Time.deltaTime;
            if (stunningTimer >= stunningTime)
            {
                Stunning();
                stunningTimer = 0;
                ableToStun = false;
            }
        }
        if (ableToDance)
        {
            dancingTimer += Time.deltaTime;
            if (dancingTimer >= dancingTime)
            {
                Dancing();
                dancingTimer = 0;
                ableToDance = false;
            }
        }
    }
    public void Flashing()
    {
        AIShootFlash aIShootFlash = GameObject.FindGameObjectWithTag("AI").GetComponent<AIShootFlash>();
        aIShootFlash.ApplyEffect();
    }
    public void Stunning()
    {
        AIShootStun aIShootFlash = GameObject.FindGameObjectWithTag("AI").GetComponent<AIShootStun>();
        aIShootFlash.ApplyEffect();
    }
    public void Dancing()
    {
        AIShootDance aIShootFlash = GameObject.FindGameObjectWithTag("AI").GetComponent<AIShootDance>();
        aIShootFlash.ApplyEffect();
    }
}
