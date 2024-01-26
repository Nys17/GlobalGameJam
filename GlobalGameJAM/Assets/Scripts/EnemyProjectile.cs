using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    float lifespan = 10f;
    public float speed = 10000f;
    public Rigidbody BulletRig;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        BulletRig = GetComponent<Rigidbody>();
        BulletRig.AddForce(transform.forward * speed * Player.gameObject.transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespan = lifespan - (1f * Time.deltaTime);
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") )
        {

            Destroy(gameObject);
        }
    }
}
