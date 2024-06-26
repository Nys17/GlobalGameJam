using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder;

public class EnemyHitLogic : MonoBehaviour
{
    [SerializeField] PathfindingAgent Agent;
    public WaveSpawner waveSpawner;      
    public float EnemyHealth;
    public Rigidbody This;
    public GameObject healthBall;
    int speed;
    int UpSpeed;
    Animator animator;
    GM gm;

    private void Awake()
    {
        if (!TryGetComponent<PathfindingAgent>(out Agent))
        {
            Debug.Log("No agent");
        }
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        EnemyHealth = 100f;
        speed = 10;
        UpSpeed = 1000;
        This = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
      
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0) 
        {
           GameObject Health = Instantiate(healthBall);
           Health.transform.position = gameObject.transform.position;
            //Destroy(gameObject);
            waveSpawner.DestroyEnemy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Agent.OnHit();
            This.AddForce(other.transform.forward * speed);
            This.AddForce(transform.up * UpSpeed);
            Destroy(other.gameObject);
            EnemyHealth -= 20;
            animator.SetBool("IsHit", true);
            Invoke("StopAnimation", 2f);
            AddScore(this.GetComponentInParent<Score>().PointAmount);
        }
    }

    void StopAnimation()
    {
        animator.SetBool("IsHit", false);
    }

    void AddScore(int score)
    {
        gm.currentScore += score;
    }
}
