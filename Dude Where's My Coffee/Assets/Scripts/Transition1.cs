using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition1 : MonoBehaviour
{
    public Canvas canvas;
    public float tillchange = 25f;
    void Start()
    {
        canvas.gameObject.SetActive(false); 
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player"){
            StartCoroutine ( End(other) );
        }
    }

    IEnumerator End(Collider2D player){
            canvas.gameObject.SetActive(true);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            
            yield return new WaitForSeconds (tillchange);
            SceneManager.LoadScene("Level1");

    }
}
