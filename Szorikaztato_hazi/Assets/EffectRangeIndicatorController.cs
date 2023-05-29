using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRangeIndicatorController : MonoBehaviour
{
    public float displayDuration = 1.0f;

    public void Show(float radius, bool hideAfterDelay = true)
    {
        transform.localScale = new Vector3(3.5f, 3.5f, 1);
        gameObject.SetActive(true);
        if(hideAfterDelay) StartCoroutine(HideAfterDelay(displayDuration));
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
