using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 200;
    public float currentHealth = 5;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("I took damage");
        currentHealth -= damage;
        if(currentHealth<0)
            Die();
            
    }
    private void Die()
    {
        Debug.Log("I died");
        Destroy(gameObject);
    }
}
