using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int maxHealth = 1000;

    public Collider playerCollider;

    void Start() {
        health = maxHealth;    
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
    }
}
