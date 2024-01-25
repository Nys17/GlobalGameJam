using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathfindingAgent : MonoBehaviour
{
#region Variables
    public NavMeshAgent agent;
    public GameObject target;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private float pathfindingMaxTime = 0f;
    private float pathfindingTime = 0f;
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
    }
    #endregion

#region Late/Update
    //Function Calls
    protected void Update()
    {
        LookAtTarget(target.transform.position);
        SetNavAgentTarget(target.transform.position);
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

    protected bool isTargetCloserThen(float targetDistance)
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
        if (pathfindingTime >= pathfindingMaxTime && isGrounded)
        {
            agent.updatePosition = true;
        }
    }

    private bool GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        return isGrounded;
    }

#endregion
}