using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    private Button level1button;
    private Button level2button;
    private Button level3button;
    private Button Tutorialbutton;
    public void Level1()
    {
        SceneManager.LoadScene("Level1"); //Moves scene to level 1
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2"); //Moves scene to level 2
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3"); //Moves scene to level 3
    }
    public void TutorialLevel()
    {
        SceneManager.LoadScene("TutorialLevel"); //Moves scene to level 4
    }
}
