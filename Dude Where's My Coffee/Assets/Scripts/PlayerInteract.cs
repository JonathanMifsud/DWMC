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
            
            // Check to see if this object can be opened
            if (currentInteractObjScript.openable)
            {
                // Check to see if the object is locked
                if (currentInteractObjScript.locked)
                {
                    // Check to see if we have the object needed to unlock
                    // Look inside inventory for needed item, if inside then unlock object
                    if (inventory.FindItem(currentInteractObjScript.itemNeeded))
                    {
                        // Needed item found
                        currentInteractObjScript.locked = false;
                        Debug.Log(currentInteractObj.name + " was unlocked");
                    } else
                    {
                        Debug.Log(currentInteractObj.name + " was not unlocked");
                    }
                } else
                {
                    // Object is not locked, open the object
                    Debug.Log(currentInteractObj.name + "is unlocked");
                    currentInteractObjScript.Open();
                }
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
