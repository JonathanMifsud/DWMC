using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int maxHealth = 100; //Max health for player
    public int currentHealth; //Variable holding player's health
    public HealthBar healthBar;

    private Animator anim = null;

    public float speed; //Movement Speed
    private float movement = 0f;
    private Rigidbody2D rb;

    //public float jumpUp; //Jump Speed - Vertical increase
    //public float jumpFall; //Fall Speed - Vertical decrease
    //public float lowJumpFall; //Fall from a small jump.

    public float jumpSpeed = 5f;

    private bool isGrounded = false; //Checks if character is on the ground. True on ground, false in air.
    public float rememberGroundedFor; //Player stays grounded
    float lastTimeGrounded; //Last time player on ground

    public Transform isGroundedChecker; //Empty object below player
    public float checkGroundRadius; //Radius between ground and player
    public LayerMask groundLayer; //Layer considered as Ground to the player

    public Vector3 respawnPoint; //Position of respawn point
    public LevelManager levelmanager;

    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //grabs player gigidbody component
        currentHealth = maxHealth; //Sets current health
        healthBar.SetMaxHealth(maxHealth);
        respawnPoint = transform.position; //First respawn point set to player's start position
        anim = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        //SmootherJump();
        CheckIfGrounded();
    }

    void FixedUpdate() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                isClimbing = true;
            }
        }else{
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                isClimbing = false;
            }
        }
        if(isClimbing == true && hitInfo.collider !=null){
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputVertical*speed);
            rb.gravityScale = 0;
        }else{
            rb.gravityScale = 5;
        }
    }
    void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if (movement > 0) //move right
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            anim.SetBool("IsWalking", true);
            anim.SetFloat("Speed", 1.0f);
            
        } else if (movement < 0) //Moveleft
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            anim.SetBool("IsWalking", true);
            anim.SetFloat("Speed", -1.0f);
            
        } else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //still
            anim.SetBool("IsWalking", false);
        }
        
    }
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
/*
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) //If the player selects the SPACE key
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpUp);
            TakeDamage(20); //Reduce health when jump - damage TEST
        }*/
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //Reduces player health
        healthBar.SetHealth(currentHealth);
    }
    /*void SmootherJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpFall - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpFall - 1) * Time.deltaTime;
        }
    }*/
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector") //If player collides with fall detector
        {
            transform.position = respawnPoint;//respawn
            levelmanager.Respawn();
            Debug.Log("Player fell"); //Testing fall 
        }
        if(collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform.position; //Sets the respawn point to checkpoint position
        }
    }
    /*private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.name.Equals("Item"))
        {
            TakeDamage(1);
        }
    }*/
}
