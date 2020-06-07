using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player; //player object
    public float offset; //Camera distance from player;
    private Vector3 playerPos; //player position
    public float offsetSmooth; //Time from camera to move from one side to another

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); //Grabs player's position and caamera
        if(player.transform.localScale.x > 0f)
        {
            playerPos = new Vector3(playerPos.x + offset, playerPos.y, playerPos.z); //Forward direction
        } else
        {
            playerPos = new Vector3(playerPos.x - offset, playerPos.y, playerPos.z); //Reverse direction
        }
        transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmooth * Time.deltaTime); //Smooth camera transition from original to player's position at smoothness offset 
    }
}
