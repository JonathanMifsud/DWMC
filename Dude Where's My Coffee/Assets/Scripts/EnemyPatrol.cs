using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true; //Starts game by moving right
    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
        }
    }
}
