using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    //public float distance;
    public bool movingRight; //Starts game by moving right
    //public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        /*transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance); //Ray created of ground and ray goes down
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); //Enemy moves left
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); //Enemy moves right
                movingRight = true;
            }
        }*/
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.CompareTag("turn"))
        {
            if (movingRight)
            {
                movingRight = false;
                Flip();
            }
            else
            {
                movingRight = true;
                Flip();
            }
            Debug.Log("flip");
        }
    }
    public void Flip() //Flip Character
    {
        Vector3 characterScale = transform.localScale;
        if (movingRight == true)
        {
            characterScale.x = -1;
        }
        if (movingRight == false)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}
