using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _CheckSphereRadius;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _CheckSphereRadius, _groundLayer);
    }
}
