using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; // Assign TextMeshPro UI object in inspector
    public TextMeshProUGUI scoreStorage;
    private float timePassed;

    void Update()
    {

        timePassed += Time.deltaTime;
        DisplayTime(timePassed);
 
    }

    void DisplayTime(float timeHappened)
    {
        int minutes = Mathf.FloorToInt(timeHappened / 60f); // Get whole minutes
        int seconds = Mathf.FloorToInt(timeHappened % 60f); // Get remaining seconds

        // Format the time string with leading zeros (00:00)
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeDisplay.text = "Time: " + timeString;

        scoreStorage.text = ((minutes * 60) + seconds).ToString();
    }
}
