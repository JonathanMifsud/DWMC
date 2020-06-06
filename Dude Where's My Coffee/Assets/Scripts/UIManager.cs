using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    //GameObject[] pauseObjects;
    // Start is called before the first frame update
    void Start()
    {
        /*Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            } else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }*/
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    /*//Reload Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    //controls scene pause
    public void pauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        } else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    //ShowOnPause objects shown
    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    //ShowOnPause objects hidden
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }*/
}
