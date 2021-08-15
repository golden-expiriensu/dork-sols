using UnityEngine;

public class AIControl : MovingControl
{
    private AIMoving _aiMoving;
    [SerializeField] private Transform _player;

    private void Awake()
    {
        _aiMoving = GetComponent<AIMoving>();
    }

    private void FixedUpdate()
    {
        _aiMoving.Move(_player.position);
        Vector3 direction = (_player.position - transform.position).normalized;
        direction = transform.TransformDirection(direction).normalized;
        OnGotAxisInput?.Invoke(direction.x, direction.z);
    }
}
