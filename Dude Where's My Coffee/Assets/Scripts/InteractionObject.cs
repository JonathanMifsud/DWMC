using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory; // If true, this object can be stored in the inventory
    public bool openable; // If true, this object can be opened
    public bool locked; // If true, this object is locked
    public GameObject itemNeeded; // Item is required in order to interact with this item

    public void DoInteraction()
    {
        // Picked up item and placed in inventory
        gameObject.SetActive(false);
    }

    public void Open()
    {
        Debug.Log("Door opened");
    }
}
