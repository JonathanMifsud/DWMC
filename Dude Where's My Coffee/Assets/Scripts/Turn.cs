using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public EnemyPatrol enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<EnemyPatrol>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.CompareTag("turn"))
        {
            if (enemy.movingRight)
            {
                enemy.movingRight = false;
                enemy.Flip();
            }
            else
            {
                enemy.movingRight = true;
                enemy.Flip();
            }
            Debug.Log("flip");
        }
    }
}
