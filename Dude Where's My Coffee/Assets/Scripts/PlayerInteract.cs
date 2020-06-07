using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInteractObj = null;
    public InteractionObject currentInteractObjScript = null;
    public Inventory inventory;

    void Update()
    {
        if (Input.GetButtonDown ("Interact") && currentInteractObj)
        {
            // Checks if object can be placed in inventory
            if (currentInteractObjScript.inventory)
            {
                inventory.AddItem(currentInteractObj);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Interactable"))
        {
            Debug.Log(other.name);
            currentInteractObj = other.gameObject;
            currentInteractObjScript = currentInteractObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("Interactable"))
        {
            if (other.gameObject == currentInteractObj)
            {
                currentInteractObj = null;
            }
        }
    }

}
