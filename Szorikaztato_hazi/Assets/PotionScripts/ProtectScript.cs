using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectScript : MonoBehaviour
{
    public void ApplyEffect(GameObject player)
    {
        Player playercomponent = player.GetComponent<Player>();
        if (playercomponent != null)
        {
            playercomponent.StartProtected();
        }
    }
}
