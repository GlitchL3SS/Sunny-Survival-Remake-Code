using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellDeath : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameTerrain;
    public GameObject gameTerrain2;
    public GameObject uI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if colliding object has "Player" tag
        {
            // Show game over screen
            gameOverScreen.SetActive(true);
            gameTerrain.SetActive(false);
            gameTerrain2.SetActive(false);
            uI.SetActive(false);

            Time.timeScale = 0f;  // Pause the game
        }
    }
}