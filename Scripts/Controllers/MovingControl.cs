using UnityEngine;

public abstract class MovingControl : MonoBehaviour, IMovingController
{
    public delegate void Moved(Transform body, Vector3 direction);
    public event Moved OnMoved;

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
}
