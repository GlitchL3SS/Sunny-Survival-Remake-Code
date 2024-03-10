using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; // Assign TextMeshPro UI object in inspector
    private float remainingTime;

    public GameObject winScreen;

    void Start()
    {
        // Set initial time from minutes and seconds (3 minutes 23 seconds)
        remainingTime = (3 * 60) + 23;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            DisplayTime(remainingTime);
        }
        else
        {
            // Timer reached 0:00, handle end of timer logic here
            Debug.Log("Timer Ended!");
            winScreen.SetActive(true);
            Time.timeScale = 0f;  // Pause the game
        }
    }

    void DisplayTime(float timeLeft)
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f); // Get whole minutes
        int seconds = Mathf.FloorToInt(timeLeft % 60f); // Get remaining seconds

        // Format the time string with leading zeros (00:00)
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeDisplay.text = "Time left: " + timeString;
    }
}
