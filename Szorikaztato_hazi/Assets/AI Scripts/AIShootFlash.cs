using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootFlash : MonoBehaviour
{
    public void ApplyEffect()
    {
        AICharacter aICharacter = GameObject.FindGameObjectWithTag("AI").GetComponent<AICharacter>();
        if (aICharacter != null)
        {
            aICharacter.StartFlashing();
        }
    }
}
