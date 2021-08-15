using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MovingControl
{
    [SerializeField] private Transform _cameraTransform;

    private enum ControlType
    {
        TurnLeft,
        TurnRight,
        Jump,
    }
    private Dictionary<ControlType, KeyCode> ControlBind = new Dictionary<ControlType, KeyCode>
        {
            { ControlType.TurnLeft, KeyCode.Q },
            { ControlType.TurnRight, KeyCode.E },
            { ControlType.Jump, KeyCode.Space },
        };

    void Update()
    {
        Vector3 direction = GetInputDirection();

        if (CanMove())
        {
            if (direction.sqrMagnitude >= 0.0001f)
            {
                _moving.Move(direction);
                _rotating.RotateByDifferenceInRotating(_cameraTransform, transform);
            }

            if (Input.GetKeyDown(ControlBind[ControlType.Jump]))
                _jumping.Jump(direction);
        }

    }

    private Vector3 GetInputDirection()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        OnGotAxisInput?.Invoke(vertical, horizontal);

        direction = transform.TransformDirection(direction);
        direction = AdjustDirectionByCamera(direction);

        return direction;
    }

    private Vector3 AdjustDirectionByCamera(Vector3 direction)
    {
        float yDifference = _cameraTransform.eulerAngles.y - transform.eulerAngles.y;
        Quaternion cameraRotation = Quaternion.Euler(0, yDifference, 0);
        direction = cameraRotation * direction;

        return direction;
    }
}
