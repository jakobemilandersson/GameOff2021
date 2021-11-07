using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 200;
    public float currentHealth = 5;
    public Slider healthBarSlier;

    public Image healthBarFillImage;
    public Color maxHealthColor;
    public Color noHealthColor;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBarSlider();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("I took damage");
        currentHealth -= damage;
        if(currentHealth<=0)
            Die();
            
    }
    private void Die()
    {
        Debug.Log("I died");
        Destroy(gameObject);
    }

    private void SetHealthBarSlider()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthBarSlier.value = healthPercentage;
        healthBarFillImage.color = Color.Lerp(noHealthColor, maxHealthColor, healthPercentage / 100);
    }

    private float CalculateHealthPercentage()
    {
        return ((float)currentHealth / (float)maxHealth) * 100;
    }
}
