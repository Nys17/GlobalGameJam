using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHitLogic : MonoBehaviour
{
    public float EnemyHealth;
    public Rigidbody This;
    int speed;
    int UpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = 100f;
        speed = 10;
        UpSpeed = 1000;
        This = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            This.AddForce(other.transform.forward * speed);
            This.AddForce(transform.up * UpSpeed);
        }
    }
}
