using UnityEngine;

public abstract class Moving : MonoBehaviour
{
    public delegate void Moved(Transform body, Vector3 direction);
    public event Moved OnMoved;

    protected void UpdateMoveEvent(Transform body, Vector3 direction)
    {
        OnMoved?.Invoke(body, direction);
    }
}
