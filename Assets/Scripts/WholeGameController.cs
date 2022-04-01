using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WholeGameController : MonoBehaviour
{

    public bool RaceFinished = false;
    public PlayerStopwatch playerStopwatch;
    public EnemyStopwatch enemyStopwatch;
    public GameObject endUI;
    public Text winnerText;

    [SerializeField]private float totalPlayerLapTime, totalEnemyLapTime;

    [SerializeField] List<float> playerLapTimes;
    [SerializeField] List<float> enemyLapTimes;

    void Update()
    {
        Time.timeScale = RaceFinished ? 0f : 1f;
        if (playerStopwatch.RaceFinished && enemyStopwatch.RaceFinished)
        {
            RaceFinished = true;
            playerLapTimes = playerStopwatch.GetLapTimes();
            enemyLapTimes = enemyStopwatch.GetLapTimes();
            
            

            for (int i = 0; i < enemyLapTimes.Count; i++)
            {
                this.totalPlayerLapTime += playerLapTimes[i];
                this.totalEnemyLapTime += enemyLapTimes[i];
            }

            if (totalPlayerLapTime < totalEnemyLapTime) //Player has less total time
            {
                winnerText.text = "Winner: Player";
            } else if (totalPlayerLapTime > totalEnemyLapTime) //Enemy has less total time
            {
                winnerText.text = "Winner: Enemy";
            } else
            {
                winnerText.text = "IT'S A TIE (how tho)"; //How can there be a tie tho? (but just in case)
            }
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
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_2":
                Debug.Log("Goes to Level 3");
                SceneManager.LoadScene("Level_3");
                break;
            case "Level_3":
                Debug.Log("Restart back to Level 1");
                SceneManager.LoadScene("Level_1");
                break;
        }
    }

    public void MainMenu()
    {
        Debug.Log("Goes to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}
