using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleoStorageEntering : MonoBehaviour
{
    private bool isCollisionActive = false; // bool, hogy bent tartozkodik az storageban
    private float waitingTimeBetweenIncreases = 0.5f;
    private Player playerComponent;
    // belep a storageba
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollisionActive = true;
            playerComponent = other.GetComponent<Player>();
            StartCoroutine(CollisionTimer()); // idozito inditasa
            playerComponent.NucleoIncrease();
        }
    }

    // kilep a storagebol
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollisionActive = false;
    }

    private System.Collections.IEnumerator CollisionTimer()
    {
        while (isCollisionActive)
        {
            yield return new WaitForSeconds(waitingTimeBetweenIncreases);
            if (!isCollisionActive) break;
            playerComponent.NucleoIncrease();
        }
    }

}
