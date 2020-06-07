using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];
    
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        // Locate the first available slot in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                // Something is done with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        // Inventory is full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item Not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == item)
            {
                // Item is found
                return true;
            }
        }
        // Item not found
        return false;
    }
}
