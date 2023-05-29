using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaborEntering : MonoBehaviour
{
    private CodeInventory inventory;
    private int counter = 0;
    private int ItemCounter = 0;
    public GameObject itemButton;
    private CanvasUtilityFunctionsScript canvas;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<CodeInventory>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasUtilityFunctionsScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && counter == 0)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    counter++;
                    inventory.isFull[i] = true;
                    GameObject valami = Instantiate(itemButton, inventory.slots[i].transform, false);
                    List<int> list = GetAminoAndNucleoFromItemButton(itemButton); // lista elso eleme az amino ara masodik a nucleo ara
                    canvas.SetCodeTextsNextToSlots(i, itemButton.name, list[0], list[1]);
                    ItemCounter++;
                    if (ItemCounter == 4)
                    {
                        SceneManager.LoadScene(3);   
                    }
                    break;
                }
                else
                {
                    ItemCounter++;
                }
            }
        }
    }

    public List<int> GetAminoAndNucleoFromItemButton(GameObject button)
    {
        List<int> result = new List<int>();
        int nucleo = 0;
        int amino = 0;
        if (itemButton.GetComponent<DancePotionButton>() != null) {
            nucleo = itemButton.GetComponent<DancePotionButton>().nucleoCost;
            amino = itemButton.GetComponent<DancePotionButton>().aminoCost;
        }
        if (itemButton.GetComponent<ProtectPotionButton>() != null)
        {
            nucleo = itemButton.GetComponent<ProtectPotionButton>().nucleoCost;
            amino = itemButton.GetComponent<ProtectPotionButton>().aminoCost;
        }
        if (itemButton.GetComponent<FlashPotionButton>() != null)
        {
            nucleo = itemButton.GetComponent<FlashPotionButton>().nucleoCost;
            amino = itemButton.GetComponent<FlashPotionButton>().aminoCost;
        }
        if (itemButton.GetComponent<StunPotionButton>() != null)
        {
            nucleo = itemButton.GetComponent<StunPotionButton>().nucleoCost;
            amino = itemButton.GetComponent<StunPotionButton>().aminoCost;
        }
        result.Add(nucleo);
        result.Add(amino);
        return result;
    }
}
