using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Control : MonoBehaviour, IMovingController
    {
        private Link _player;

        public delegate void GetMovingInput(float vertical, float horizontal);
        public GetMovingInput OnGotAxisInput;

        private bool _canMove = true;

        private void Awake()
        {
            _player = GetComponent<Link>();
        }

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
                    _player.Moving.Move(direction);
                    _player.Rotating.RotateTransformForwardCamera();
                }

                if (Input.GetKeyDown(ControlBind[ControlType.Jump]))
                    _player.Jumper.Jump(direction);
            }

        }

        private bool CanMove()
        {
            return _canMove && _player.GroundCheck.IsGrounded();
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
            float yDifference = _player.CameraTransform.eulerAngles.y - transform.eulerAngles.y;
            Quaternion cameraRotation = Quaternion.Euler(0, yDifference, 0);
            direction = cameraRotation * direction;

            return direction;
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
}
