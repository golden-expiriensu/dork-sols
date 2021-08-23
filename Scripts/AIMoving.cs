using UnityEngine;
using UnityEngine.AI;

public class AIMoving : Moving
{
    private NavMeshAgent _navAgent;


    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        UpdateMoveEventVelocity();
        if(_navAgent.remainingDistance < _navAgent.stoppingDistance)
            _navAgent.isStopped = true;
        else _navAgent.isStopped = false;
    }

    private void UpdateMoveEventVelocity()
    {
        UpdateMoveEvent(transform, Vector3.ClampMagnitude(_navAgent.velocity, 1));
    }

    public void Move(Vector3 targetPosition)
    {
        _navAgent.SetDestination(targetPosition);
    }
}
