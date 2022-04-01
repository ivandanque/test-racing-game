using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WholeGameController : MonoBehaviour
{

    public bool RaceFinished = false;
    public PlayerStopwatch playerStopwatch;
    public EnemyStopwatch enemyStopwatch;

    
    void Update()
    {
        Time.timeScale = RaceFinished ? 0f : 1f;
        if (playerStopwatch.RaceFinished && enemyStopwatch.RaceFinished)
        {
            RaceFinished = true;
            GameObject endUI = GameObject.Find("UI").transform.GetChild(0).transform.GetChild(2).gameObject;
            endUI.SetActive(true);
        }
    }

    public void NextLevel()
    {
        Debug.Log("Goes to Next Level");
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_1":
                Debug.Log("Goes to Level 2");
                break;
            case "Level_2":
                Debug.Log("Goes to Level 3");
                break;
            case "Level_3":
                Debug.Log("Restart back to Level 1");
                break;
        }
    }

    public void MainMenu()
    {
        Debug.Log("Goes to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
