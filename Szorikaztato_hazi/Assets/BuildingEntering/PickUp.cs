using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    private int counter = 0;
    public GameObject itemButton;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
                    if(itemButton.tag == "Glove")
                    {
                        PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
                        playerMovement.speed += 1.0f;
                    } 
                    else if (itemButton.tag == "Sack")
                    {
                        Player playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                        playerComponent.MaximumScore = 150;
                    }
                    else if (itemButton.tag == "Cape")
                    {
                        Player playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                        playerComponent.haveCape = true;
                    }
                    break;
                }

            }
        }
    }
}
