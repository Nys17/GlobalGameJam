using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof((NavMeshAgent, Rigidbody)))]
public class PathfindingAgent : MonoBehaviour
{
#region Variables
    public NavMeshAgent agent;
    public GameObject target;

    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;

    [SerializeField] private float pathfindingMaxTime = 0f;
    [SerializeField] private float pathfindingTime = 0f;
    #endregion

#region Initialisation
    //Safety Checks
    private void Awake()
    {
        if (agent == null)
        {
            if (!TryGetComponent<NavMeshAgent>(out agent))
            {
                Debug.Log("No navmesh agent");
            }
        }

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("No target for: " + this.name);
        }

        if (!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.Log("No rigidbody");
        }

    }
    #endregion

#region Late/Update
    //Function Calls
    protected void Update()
    {
        if (agent.updatePosition)
        {
            LookAtTarget(target.transform.position);
            SetNavAgentTarget(target.transform.position);
        }
        PathfindingTimer();
    }
    #endregion

#region Custom Methods

    //Orient to target, will not change Y rotation
    private void LookAtTarget(Vector3 targetVector)
    {
        Vector3 LookVector = new Vector3(targetVector.x, this.transform.position.y, targetVector.z);
        this.transform.LookAt(LookVector);
    }

    //Change navmesh goal to target
    private void SetNavAgentTarget(Vector3 targetVector)
    {
        agent.SetDestination(targetVector);
    }

    protected bool IsTargetCloserThen(float targetDistance)
    {
        if (agent.remainingDistance <= targetDistance)
        {
            return true;
        }
        return false;
    }

    public void OnHit()
    {
        agent.updatePosition = false;
    }

    private void PathfindingTimer()
    {
        pathfindingTime += Time.deltaTime;
        if (GroundCheck() == true && pathfindingTime >= pathfindingMaxTime)
        {
            agent.nextPosition = this.transform.position;
            agent.updatePosition = true;
            pathfindingTime = 0;
            rb.velocity = Vector3.zero;
        }
        else if (agent.updatePosition == true)
        {
            pathfindingTime = 0;
        }
    }

    private bool GroundCheck()
    {
        if (agent.updatePosition == false)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            return isGrounded;
        }
        return true;
    }

#endregion
}