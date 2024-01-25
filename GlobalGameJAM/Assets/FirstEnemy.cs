using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
   public WaveSpawner waveSpawner;
    public float damage;
    RangefinderAgent rangefinderAgent;
    float attackCoolDown;
    bool canAttack;
    void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();

        attackCoolDown = 5f;
        rangefinderAgent = this.GetComponent<RangefinderAgent>();
        rangefinderAgent.targetDistance = 5f;
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

    void ChargedAttack()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20);
        canAttack = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  other.gameObject.GetComponent<Player>.health = other.gameObject.GetComponent<Player>.health - damage;
        }
    }
}
