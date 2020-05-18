using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //Movement Speed
    private Rigidbody2D rb;

    public float jumpUp; //Jump Speed - Vertical increase
    public float jumpFall; //Fall Speed - Vertical decrease
    public float lowJumpFall; //Fall from a small jump.

    bool isGrounded = false; //Checks if character is on the ground. True on ground, false in air.
    public Transform isGroundedChecker; //Empty object below player
    public float checkGroundRadius; //Radius between ground and player
    public LayerMask groundLayer; //Layer considered as Ground to the player
    public float rememberGroundedFor; //Player stays grounded
    float lastTimeGrounded; //Last time player on ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        SmootherJump();
        CheckIfGrounded();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); //If the player selects LEFT/A or RIGHT/D keys
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) //If the player selects the SPACE key
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpUp);
        }
    }
    void SmootherJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpFall - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpFall - 1) * Time.deltaTime;
        }
    }
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null) //If player has collided with an object
        {
            isGrounded = true; //Player on ground
        } else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false; //Player not on ground
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Lift"))
        {
            this.transform.parent = collision.transform;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Lift"))
        {
            this.transform.parent = null;
        }
    }
}
