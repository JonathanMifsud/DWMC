using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject Checkpoints;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Escape();
        Pause();
    }
    void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu"); //Moves scene to Main Menu
        }
    }
    /*void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }*/
    public void Respawn()
    {
        Debug.Log("Respawn"); //test respawn
        player.currentHealth = player.maxHealth; //Resets healthbar
        player.transform.position = Checkpoints.transform.position;

    }
}
