using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int AminoScore = 0;
    public int NucleoScore = 0;
    public int MaximumScore = 100;
    public TextMeshProUGUI AminoText;
    public TextMeshProUGUI NucleoText;
    public EffectRangeIndicatorController effectRangeIndicatorControllerPrefab;

    public float protectedTime = 10.0f;                  //ennyi ideig hat ez a protection
    private float protectedTimer = 0.0f;
    public bool isProtected = false;
    public bool haveCape = false;

    void Start()
    {
        DanceScript.effectRangeIndicatorController = effectRangeIndicatorControllerPrefab;
        StunScript.effectRangeIndicatorController = effectRangeIndicatorControllerPrefab;
    }

    private void Update()
    {
        GameObject AI = GameObject.FindGameObjectWithTag("AI");
		float distance = Vector3.Distance(transform.position, AI.transform.position);
		if (isProtected)
        {
            protectedTimer += Time.deltaTime;
            if (protectedTimer >= protectedTime)
            {
                protectedTimer = 0;
                isProtected = false;
            }
        }

        AminoText.text = "Amino: " + AminoScore.ToString();
        NucleoText.text = "Nucleo: " + NucleoScore.ToString();
    }
    public void StartProtected()
    {
        isProtected = true;
        protectedTimer = 0;
    }

    public void AminoIncrease()
    {
        if(MaximumScore >= AminoScore + 20)
        {
            AminoScore += 20;
        }
        else if(MaximumScore >= AminoScore + 15)
        {
			AminoScore += 15;
		}
		else if (MaximumScore >= AminoScore + 10)
        {
            AminoScore += 10;
        }
		else if (MaximumScore >= AminoScore + 5)
		{
			AminoScore += 5;
		}
	}
    public void NucleoIncrease()
    {
		if (MaximumScore >= NucleoScore + 20)
		{
			NucleoScore += 20;
		}
		else if (MaximumScore >= NucleoScore + 15)
		{
			NucleoScore += 15;
		}
		else if (MaximumScore >= NucleoScore + 10)
		{
			NucleoScore += 10;
		}
		else if (MaximumScore >= NucleoScore + 5)
		{
			NucleoScore += 5;
		}
	}

}
