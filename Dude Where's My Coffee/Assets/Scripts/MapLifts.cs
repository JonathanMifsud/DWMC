using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLifts : MonoBehaviour
{
    /*float dirX, moveSpeed = 2f; //Movement speed
    bool moveRight = true; //Automatically starts moving right*/

    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        /*if (transform.position.x > 40f && transform.position.x <= 48f) //Checks position
        {
            moveRight = false;
        }
        if (transform.position.x < 40f && transform.position.x >= 32f) //Checks position
        {
            moveRight = true;
        }
        if (moveRight) //Moves object
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }*/
    }
}
