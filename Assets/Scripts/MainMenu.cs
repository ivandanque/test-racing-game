using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel_1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void LoadLevel_3()
    {
        // SceneManager.LoadScene("Level_1");
    }
}
