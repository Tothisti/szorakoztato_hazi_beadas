using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashPotionButton : MonoBehaviour
{
    private Button button;
    private GameObject player;
    private FlashScript flashPotion;
    public int nucleoCost = 35;
    public int aminoCost = 35;
    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        flashPotion = GetComponent<FlashScript>();

        button.onClick.AddListener(ApplyFlashPotion);
    }

    // Update is called once per frame
    void ApplyFlashPotion()
    {
        Player playerComponent = player.GetComponent<Player>();
        if (playerComponent.NucleoScore >= 35 && playerComponent.AminoScore >= 35)
        {
            playerComponent.NucleoScore -= nucleoCost;
            playerComponent.AminoScore -= aminoCost;
            if (flashPotion != null)
            {
                flashPotion.ApplyEffect(player);
            }
        }
    }
}
