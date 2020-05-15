using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //Movement Speed
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")); //Left Arrow & Right Arrow Keys
        moveVelocity = moveInput * speed; 
        //KeyInput();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
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
