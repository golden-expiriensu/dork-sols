using UnityEngine;

public class MovingControl : MonoBehaviour, IMovingController
{
    protected Moving _moving;
    protected Jumping _jumping;
    protected Rotating _rotating;
    protected GroundCheck _groundCheck;

    public AxisInput OnGotAxisInput;

    private bool _canMove = true;

    private void Awake()
    {
        _moving = GetComponent<Moving>();
        _jumping = GetComponent<Jumping>();
        _rotating = GetComponent<Rotating>();
        _groundCheck = GetComponent<GroundCheck>();
    }

    protected bool CanMove()
    {
        return _canMove && _groundCheck.IsGrounded();
    }

    public void ForbidMove()
    {
        _canMove = false;
    }

    public void AllowMove()
    {
        _canMove = true;
    }

    public void SubscribeOnAxisInput(AxisInput method)
    {
        OnGotAxisInput += method;
    }
}
