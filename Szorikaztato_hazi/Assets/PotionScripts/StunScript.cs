using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunScript : MonoBehaviour
{
    public float effectRange = 7.5f;
    public static EffectRangeIndicatorController effectRangeIndicatorController;
    public void ApplyEffect(GameObject player)
    {
        if (effectRangeIndicatorController != null)
        {
            effectRangeIndicatorController.Show(effectRange);
        }
        Collider2D[] nearbyAIs = Physics2D.OverlapCircleAll(player.transform.position, effectRange);

        foreach (Collider2D aiCollider in nearbyAIs)
        {
            if (aiCollider.CompareTag("AI"))
            {
                AICharacter ai = aiCollider.GetComponent<AICharacter>();
                if (ai != null)
                {
                    ai.StartStunning();
                }
            }
        }
    }
}
