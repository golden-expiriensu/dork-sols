using UnityEngine;
using UnityEngine.AI;

public class AIMoving : MonoBehaviour
{
    private NavMeshAgent _navAgent;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPosition)
    {
        _navAgent.SetDestination(targetPosition);
    }
}
