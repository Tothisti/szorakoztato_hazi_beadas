using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootDance : MonoBehaviour
{
    public void ApplyEffect()
    {
        Collider2D[] nearbyAIs = Physics2D.OverlapCircleAll(GameObject.FindGameObjectWithTag("AI").transform.position, 20.0f);

        foreach (Collider2D aiCollider in nearbyAIs)
        {
            if (aiCollider.CompareTag("Player"))
            {
                PlayerDance ai = aiCollider.GetComponent<PlayerDance>();
                if (ai != null)
                {
                    ai.StartDancing();
                }
            }
        }
    }
}
