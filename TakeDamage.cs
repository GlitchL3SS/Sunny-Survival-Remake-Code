using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the health bar script

    void OnTriggerEnter2D(Collider2D other) // Use OnTriggerEnter2D for 2D collisions
    {
        if (other.gameObject.tag == "Hazard")
        {
            healthBar.UpdateHealth(-1.0f); // Call health bar function with damage amount
        }
    }
}