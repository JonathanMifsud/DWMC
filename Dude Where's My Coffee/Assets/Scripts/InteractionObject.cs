using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    void DoInteraction()
    {
        // Picked up item and placed in inventory
        gameObject.SetActive(false);
    }
}
