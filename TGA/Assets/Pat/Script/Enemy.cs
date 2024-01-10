using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : Character
{
    public enum EnemyType
    {
        normal, elite, boss
    }
    public EnemyType type;
    [HideInInspector]public NavMeshAgent agent;
    public float detectionRange;
    public float attackRange;
    public Skill lightAttack;
    public Skill heavyAttack;
    public Skill specialAttack;
    private bool inCombat = false;
    private Vector3 originatedPos;
    private GameObject player;
    private State currentState;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        originatedPos = this.transform.position;
        agent.speed = moveSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = new Idle(this, player);
    }

    private void Update()
    {
        currentState.Process();
    }

    public bool DetectPlayer()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = this.gameObject.transform.position;
        if ((enemyPos - playerPos).magnitude <= detectionRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}