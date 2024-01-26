using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    
    private EventInstance footsteps;

    public CharacterController controller;
    [SerializeField] Vector3 velocity;

    public Transform groundCheck;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 10f;
    public float boostHeight = 20f;
    public int PlayerHealth = 100;
    
    
    public LayerMask groundMask;


    public Transform playerBody;

    [SerializeField] bool isGrounded;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        footsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0); //main menu 
        }

        if (PlayerHealth >100)
        {
            PlayerHealth = 100;
        }
        Vector2 NewMove = playerControls.Gameplay.Move.ReadValue<Vector2>();
       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = NewMove.x; //Input.GetAxis("Horizontal");
        float z = NewMove.y; // Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)== true)
        {
            speed = 20f;
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speed = 12f;
        }
        controller.Move(velocity * Time.deltaTime);

        UpdateSound();
    }

    private void UpdateSound()
    {
        if (isGrounded && (playerControls.Gameplay.Move.ReadValue<Vector2>() != Vector2.zero))
        {
            PLAYBACK_STATE playbackState;
            footsteps.getPlaybackState(out playbackState);
            if (playbackState == PLAYBACK_STATE.STOPPED)
            {
                footsteps.start();
            }
        }
        else
        {
            footsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            velocity.y = Mathf.Sqrt(boostHeight * -2f * gravity);
            velocity.y += gravity * Time.deltaTime;
        }
        if (other.gameObject.CompareTag("Health"))
        {
            PlayerHealth = PlayerHealth + 20;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
           PlayerHealth = PlayerHealth - 20;
        }

       
        
    }
}
