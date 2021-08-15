using UnityEngine;

public class MovingControl : MonoBehaviour, IMovingController
{
    public AxisInput OnGotAxisInput;

    protected bool _canMove = true;

    protected virtual bool CanMove()
    {
        return _canMove;
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
