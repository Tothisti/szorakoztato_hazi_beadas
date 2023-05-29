using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DancePotionButton : MonoBehaviour
{
    private Button button;
    private GameObject player;
    private DanceScript dancePotion;
    public int nucleoCost = 30;
    public int aminoCost = 40;

    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        dancePotion = GetComponent<DanceScript>();

        button.onClick.AddListener(ApplyDancePotion);
    }

    void ApplyDancePotion()
    {
        Player playerComponent = player.GetComponent<Player>();
        if(playerComponent.NucleoScore >= 30 && playerComponent.AminoScore >= 40)
        {
            playerComponent.NucleoScore -= nucleoCost;
            playerComponent.AminoScore -= aminoCost;
            if (dancePotion != null)
            {
                dancePotion.ApplyEffect(player);
            }
        }
        
    }
}
