using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInteractObj = null;

    void Update()
    {
        if (Input.GetButtonDown ("Interact") && currentInteractObj)
        {
            currentInteractObj.SendMessage("DoInteraction");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Interactable"))
        {
            Debug.Log(other.name);
            currentInteractObj = other.gameObject;
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
