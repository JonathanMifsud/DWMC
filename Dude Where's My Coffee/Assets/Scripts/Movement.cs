using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float distance;
    private BoxCollider2D boxCollider2D;
    public LayerMask whatIsLadder;
    [SerializeField]private LayerMask groundMask;
    private bool isClimbing;
    private float inputVertical;
    public float speed; //Movement Speed
    private float movement = 0f;
    private Rigidbody2D rb;

    public int maxHealth = 100; //Max health for player
    public int currentHealth; //Variable holding player's health
    public HealthBar healthBar;
    public Vector3 respawnPoint;
    public LevelManager levelmanager;

    private Animator anim = null;
    public float jumpVelocity = 15f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
        anim = this.GetComponent<Animator>();
    }

    
    void FixedUpdate() {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider !=null){
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                isClimbing = true;
            }
        }else {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                isClimbing = false;
            }
        }
        
        if(isClimbing == true && hitInfo.collider !=null){
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        } else{
            rb.gravityScale = 5;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement();
    }

    private bool IsGrounded(){
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider !=null;
    }

    private void HandleMovement(){
        float moveSpeed = 10f;
        if (Input.GetKey(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.SetBool("isWalking", true);
            anim.SetFloat("Speed", -1.0f);
        } else{
            if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
                anim.SetBool("isWalking", true);
                anim.SetFloat("Speed", 1.0f);
            }else{
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("isWalking", false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //Reduces player health
        healthBar.SetHealth(currentHealth);
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

}
