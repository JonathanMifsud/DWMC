using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
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
            yield return new WaitForSeconds (tillchange);
            SceneManager.LoadScene("Level2");

    }
}
