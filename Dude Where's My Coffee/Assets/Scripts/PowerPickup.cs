using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public float multiplier = 1.15f;
    public float duration = 4f;

    public float respawn = 9f;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player"){
            StartCoroutine ( Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider2D player){
        //Effect
        Movement stats = player.GetComponent<Movement>();
        stats.jumpVelocity *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.jumpVelocity /= multiplier;

        yield return new WaitForSeconds(respawn);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;

        
    }
}
