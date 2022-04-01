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
    }

    public void MainMenu()
    {
        Debug.Log("Goes to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
