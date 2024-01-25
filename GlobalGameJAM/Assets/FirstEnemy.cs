using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
   public WaveSpawner waveSpawner;
    public float damage;
    void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            waveSpawner.DestroyEnemy(gameObject);
            
        }
    }

    void ChargedAttack()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          //  other.gameObject.GetComponent<Player>.health = other.gameObject.GetComponent<Player>.health - damage;
        }
    }
}
