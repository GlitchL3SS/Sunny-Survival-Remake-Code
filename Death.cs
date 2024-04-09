using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameTerrain;
    public GameObject gameTerrain2;
    public GameObject leaderboard;

    public HealthBar healthBar; // Reference to the health bar script

    void Update()
    {
        if (healthBar.currentHealth == 0)
        {
            // Show game over screen
            gameOverScreen.SetActive(true);
            gameTerrain.SetActive(false);
            gameTerrain2.SetActive(false);
            leaderboard.SetActive(true);

            Time.timeScale = 0f;  // Pause the game
        }
    }
}