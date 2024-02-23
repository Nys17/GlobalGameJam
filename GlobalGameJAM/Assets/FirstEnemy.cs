using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstEnemy : MonoBehaviour
{
   public WaveSpawner waveSpawner;
    public int damage;
    RangefinderAgent rangefinderAgent;
    float attackCoolDown;
    bool canAttack;
    Animator animator;
    void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        animator= GetComponent<Animator>();
        attackCoolDown = 5f;
        rangefinderAgent = this.GetComponent<RangefinderAgent>();
        rangefinderAgent.targetDistance = 1.5f;
        damage = 20;
    }

    // Update is called once per frame
    void Update()
    {
                if (rangefinderAgent.MeasureDistanceToTarget()) { 

            if (canAttack)
            {
              
                ChargedAttack();

            }

            attackCoolDown = attackCoolDown - (1f * Time.deltaTime); /// timer

            if (attackCoolDown <= 0)
            {
                canAttack = true;
                attackCoolDown = 5f;
            }
        
        
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("PlayerBullet"))
    //    {
    //        waveSpawner.DestroyEnemy(gameObject);
            
    //    }
    //}

    void DisableEnableNavMeshAgent()
    {
        if (GetComponent<NavMeshAgent>().enabled == true && GetComponent<RangefinderAgent>().enabled == true)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<RangefinderAgent>().enabled = false;
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<RangefinderAgent>().enabled = true;
        }
    }
    void ChargedAttack()
    {
        animator.SetBool("IsAttacking", true);
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20);
        canAttack = false;
        animator.SetBool("IsAttacking", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().PlayerHealth = other.gameObject.GetComponent<Player>().PlayerHealth - damage;
        }
    }
}
