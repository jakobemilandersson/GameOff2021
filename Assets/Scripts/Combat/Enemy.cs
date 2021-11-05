using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 200;
    public float currentHealth = 5;
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
        
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("I took damage");
        currentHealth -= damage;
        if(currentHealth<0)
            Debug.Log("I died");
    }

    void GiveDamage(GameObject target)
    {
        Debug.Log("[GiveDamage] target: " + target.name);
    }

    private void OnCollisionEnter(Collision other) {
        GameObject collidingObjectRoot = other.gameObject.transform.root.gameObject;
        if(collidingObjectRoot.tag == "Player")
        {
            float _attackTime = Time.time;
            Debug.Log("[OnCollisionStay] other: " + collidingObjectRoot.name + " | " + collidingObjectRoot.tag + " ~ " + _attackTime);
            collidingObjectRoot.GetComponent<PlayerHealth>().DecrementHealth(damage);
            lastAttack = _attackTime;
        }
    }

    private void OnCollisionStay(Collision other) {
        GameObject collidingObjectRoot = other.gameObject.transform.root.gameObject;
        if(collidingObjectRoot.tag == "Player" && lastAttack + attackSpeed <= Time.time)
        {
            float _attackTime = Time.time;
            Debug.Log("[OnCollisionStay] other: " + collidingObjectRoot.name + " | " + collidingObjectRoot.tag + " ~ " + _attackTime);
            collidingObjectRoot.GetComponent<PlayerHealth>().DecrementHealth(damage);
            lastAttack = _attackTime;
        }
    }
}
