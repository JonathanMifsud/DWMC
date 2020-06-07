using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
   public Transform Player;
   public float dampTime = 0.4f;
   private Vector3 camperaPos;
   private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        camperaPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, camperaPos, ref velocity, dampTime);
    }
}
