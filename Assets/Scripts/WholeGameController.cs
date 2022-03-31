using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
