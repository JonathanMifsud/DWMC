using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //Movement Speed
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
    }
    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Player Jumps
            //Vector2.up
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Player moves right
            //Vector2.right
        }
    }
}
