using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StunPotionButton : MonoBehaviour
{
    private Button button;
    private GameObject player;
    private StunScript stunPotion;
    public int nucleoCost = 65;
    public int aminoCost = 40;
    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        stunPotion = GetComponent<StunScript>();

        button.onClick.AddListener(ApplyStunPotion);
    }

    // Update is called once per frame
    void ApplyStunPotion()
    {
        Player playerComponent = player.GetComponent<Player>();
        if (playerComponent.NucleoScore >= 65 && playerComponent.AminoScore >= 40)
        {
            playerComponent.NucleoScore -= nucleoCost;
            playerComponent.AminoScore -= aminoCost;
            if (stunPotion != null)
            {
                stunPotion.ApplyEffect(player);
            }
        }
    }
}
