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
