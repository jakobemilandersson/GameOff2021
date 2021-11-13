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
    public int damage = 10;
    public float attackSpeed = 0.6f;
    [SerializeField]
    private float lastAttack;
    void Start()
    {
        lastAttack = Time.time;
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
    void GiveDamage(GameObject target)
    {
        Debug.Log("[GiveDamage] target: " + target.name);
    }

    private void OnTriggerEnter(Collider other) {
        GameObject collidingObjectRoot = other.gameObject.transform.root.gameObject;
        if(collidingObjectRoot.tag == "Player")
        {
            float _attackTime = Time.time;
            collidingObjectRoot.GetComponent<PlayerHealth>().DecrementHealth(damage);
            lastAttack = _attackTime;
        }
    }

    private void OnTriggerStay(Collider other) {
        GameObject collidingObjectRoot = other.gameObject.transform.root.gameObject;
        if(collidingObjectRoot.tag == "Player" && lastAttack + attackSpeed <= Time.time)
        {
            float _attackTime = Time.time;
            collidingObjectRoot.GetComponent<PlayerHealth>().DecrementHealth(damage);
            lastAttack = _attackTime;
        }
    }
}
