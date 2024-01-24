using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
   
    public Rigidbody BulletRig;
    float lifespan = 10f;
    public float speed = 10000f;
    // Start is called before the first frame update
    void Start()
    {
        BulletRig.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        lifespan = lifespan - (1f*Time.deltaTime);
        // Vector3 move = new Vector3(1, 0, 0)*speed *Time.deltaTime;
        // transform.Translate(move);

        
        
        if (lifespan<= 0f)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("EnemyTwo") || other.gameObject.CompareTag("EnemyThree"))
        {
            
            Destroy(gameObject);
        }
    }
}
