using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float attackRange = 2;
    public bool playerInAttackRange;
    [SerializeField]
    float rotationSpeed = 5f;
    // Start is called before the first frame update
    private void Awake() {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);
        if(!playerInAttackRange)
            ChasePlayer();
        if(playerInAttackRange)
            AttackPlayer();
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.position);
        //Attack
    }
}
