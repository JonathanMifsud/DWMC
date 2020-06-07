using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory; // If true, this object can be stored in the inventory

    void DoInteraction()
    {
        // Picked up item and placed in inventory
        gameObject.SetActive(false);
    }
}
