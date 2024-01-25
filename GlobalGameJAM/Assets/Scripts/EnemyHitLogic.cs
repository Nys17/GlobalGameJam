using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder;

public class EnemyHitLogic : MonoBehaviour
{
    [SerializeField] PathfindingAgent Agent;
    public float EnemyHealth;
    public Rigidbody This;
    public GameObject healthBall;
    int speed;
    int UpSpeed;

    private void Awake()
    {
        if (!TryGetComponent<PathfindingAgent>(out Agent))
        {
            Debug.Log("No agent");
        }
    }

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
        if (EnemyHealth <= 0) 
        {
            GameObject Health = Instantiate(healthBall);
            Health.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Agent.OnHit();
            This.AddForce(other.transform.forward * speed);
            This.AddForce(transform.up * UpSpeed);
            EnemyHealth = 0;
        }
    }
}
