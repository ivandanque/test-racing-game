using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStopwatch : MonoBehaviour
{
    public Text timerText;
    public Text lapText;
    [SerializeField] private float timer = 0f;
    [SerializeField] private int lapCount;
    [SerializeField] private bool incomingLap = false;

    [SerializeField] private CheckpointHandler checkpointHandler;

    [SerializeField] private List<float> lapTimes;

    public bool RaceFinished = false;

    void Start()
    {
        lapTimes = new List<float>();
        lapCount = 1;
        lapText.text = "Player Lap: " + lapCount + "/3";
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (lapTimes.Count == 0)
        {
            timerText.text = "Player Time: " +
                "\nLap 1: " + timer.ToString();
        }
        else if (lapTimes.Count == 1)
        {
            timerText.text = "Player Time: " +
                "\nLap 1: " + lapTimes[0] +
                "\nLap 2: " + timer.ToString();
        }
        else if (lapTimes.Count == 2)
        {
            timerText.text = "Player Time: " +
                "\nLap 1: " + lapTimes[0] +
                "\nLap 2: " + lapTimes[1] +
                "\nLap 3: " + timer.ToString();
        }
        else
        {
            float totalLap = lapTimes[0] + lapTimes[1] + lapTimes[2];
            float minuteValue = 0;

            while (totalLap >= 60f)
            {
                totalLap -= 60f;
                minuteValue++;
            }
            timerText.text = "Player Time: " +
                "\nLap 1: " + lapTimes[0] +
                "\nLap 2: " + lapTimes[1] +
                "\nLap 3: " + lapTimes[2] +
                "\n\n\nTotal Time: " + minuteValue + ":" + totalLap;
        }
        ReferenceCheckpoints(checkpointHandler.GetNextCheckpoint(0));
    }

    public void ReferenceCheckpoints(int checkpointsPassed)
    {
        Debug.Log("Checkpoint: " + checkpointsPassed);
        if (checkpointsPassed == 1 && incomingLap)
        {
            lapCount++;
            incomingLap = false;
            if (lapCount >= 4)
            {
                lapCount = 3;
                lapText.text = "Player Lap: " + lapCount + "/3";
            }
            else { 
            lapText.text = "Player Lap: " + lapCount + "/3";
            }

            if (!RaceFinished)
            {
                lapTimes.Add(timer);
            }

            if (lapTimes.Count == 3)
            {
                RaceFinished = true;
            }
            timer = 0f;
        }

        if (checkpointsPassed == 0)
        {
            incomingLap = true;
        }
    }
}
