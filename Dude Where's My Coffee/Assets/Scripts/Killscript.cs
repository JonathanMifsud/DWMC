using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killscript : MonoBehaviour
{
     public LevelManager levelmanager;
    public Movement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if (player.currentHealth > 0)
            {
                player.TakeDamage(25);
                Debug.Log("Took damage");
            }
            else if (player.currentHealth <= 0)
            {
                levelmanager.Respawn(); //Respawn Player
                Debug.Log("Player killed"); //Test death collision
            }
        }
    }
}
