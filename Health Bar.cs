using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Assign the slider object in inspector
    public float currentHealth; // Variable to store current health

    void Start()
    {
        currentHealth = healthSlider.maxValue; // Set initial health to max value
    }

    void Update()
    {
        healthSlider.value = currentHealth; // Update slider value based on current health
    }

    public void UpdateHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, healthSlider.maxValue); // Update health with clamping
    }
}
