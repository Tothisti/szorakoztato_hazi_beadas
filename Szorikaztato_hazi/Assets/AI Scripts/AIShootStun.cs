using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootStun : MonoBehaviour
{
    public void ApplyEffect()
    {
        Collider2D[] nearbyAIs = Physics2D.OverlapCircleAll(GameObject.FindGameObjectWithTag("AI").transform.position, 5.5f);

        foreach (Collider2D aiCollider in nearbyAIs)
        {
            if (aiCollider.CompareTag("Player"))
            {
                PlayerStunned ai = aiCollider.GetComponent<PlayerStunned>();
                if (ai != null)
                {
                    ai.StartStunned();
                }
            }
        }
    }
}
