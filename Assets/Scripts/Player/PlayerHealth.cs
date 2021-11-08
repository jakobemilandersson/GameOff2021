using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int maxHealth = 100;

    public Collider playerCollider;
    [Tooltip("Reference to the staminaSlider")]
    public Slider healthSlider;
    [Tooltip("Reference to the staminaHealth")]
    public TextMeshProUGUI healthText;

    void Start() {
        // Check if public variables have been set up, else try to find some
        if(playerCollider == null)
            playerCollider = GetComponentInChildren<CapsuleCollider>();
        if(healthSlider == null)
        {
            foreach(Slider _slider in GetComponentsInChildren<Slider>())
            {
                if(_slider.name == "HealthBar")
                    healthSlider = _slider;
            }
        }
        if(healthText == null)
        {
            foreach(TextMeshProUGUI _text in GetComponentsInChildren<TextMeshProUGUI>())
            {
                if(_text.name == "HealthText")
                    healthText = _text;
            }
        }

        // Set health to max health
        health = maxHealth;

        // Set up health bar slider
        healthSlider.minValue = 0;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        // Health bar text
        healthText.text = health.ToString();
    }

    public void DecrementHealth(int value)
    {
        if(health - value > 0)
        {
            health -= value;
        } else
        {
          health = 0;  
            // TODO: Game Over Screen?
        }
        healthSlider.value = health;
        healthText.text = health.ToString();
    }

    public void IncrementHealth(int value)
    {
        if(health + value <= maxHealth)
        {
            health += value;
        } else 
        {
            health = maxHealth;
        }
        healthSlider.value = health;
        healthText.text = health.ToString();
    }
}
