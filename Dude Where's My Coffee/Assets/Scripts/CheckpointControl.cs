using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    public Sprite FalseCheckpoint;
    public Sprite TrueCheckpoint;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool CheckpointReached;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>(); //Grabs sprite
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //If player collides with checkpoint object
        {
            checkpointSpriteRenderer.sprite = TrueCheckpoint; //Changes sprite
            CheckpointReached = true; //Sets Checkpoint progress
        }
    }
}
