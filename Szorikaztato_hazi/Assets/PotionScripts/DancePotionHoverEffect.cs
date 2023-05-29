using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancePotionHoverEffect : MonoBehaviour
{
    public float effectRange = 7.5f;
    // Start is called before the first frame update
    public void HoverIn()
    {
        EffectRangeIndicatorController effectRangeIndicatorController = DanceScript.effectRangeIndicatorController;
        if (effectRangeIndicatorController != null)
        {
            effectRangeIndicatorController.Show(effectRange, false);
        }
    }

    public void HoverOut()
    {
        EffectRangeIndicatorController effectRangeIndicatorController = DanceScript.effectRangeIndicatorController;
        if (effectRangeIndicatorController != null)
        {
            effectRangeIndicatorController.Hide();
        }
    }

}
