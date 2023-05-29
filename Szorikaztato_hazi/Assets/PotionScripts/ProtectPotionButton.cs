using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectPotionButton : MonoBehaviour
{
    private Button button;
    private GameObject player;
    private ProtectScript protectPotion;
    public int nucleoCost = 60;
    public int aminoCost = 90;
    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        protectPotion = GetComponent<ProtectScript>();

        button.onClick.AddListener(ApplyProtectPotion);
    }

    void ApplyProtectPotion()
    {
        Player playerComponent = player.GetComponent<Player>();
        if (playerComponent.NucleoScore >= 60 && playerComponent.AminoScore >= 90)
        {
            playerComponent.NucleoScore -= nucleoCost;
            playerComponent.AminoScore -= aminoCost;
            if (protectPotion != null)
            {
                protectPotion.ApplyEffect(player);
            }
        }
    }
}
