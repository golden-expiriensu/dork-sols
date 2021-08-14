using UnityEngine;

namespace Player
{
    public class AnimationObserver : MonoBehaviour
    {
        private Link _player;
        private AnimationSwitcher _animationSwitcher;

        private bool _currentIsGrounded = true;
        private bool _currentIsRun = false;

        private void Awake()
        {
            _player = GetComponent<Link>();
            _animationSwitcher = GetComponent<AnimationSwitcher>();
        }

        private void Start()
        {
            _player.Tricks.OnPlayerJumped += _animationSwitcher.StartJump;
        }

        private void FixedUpdate()
        {
            CheckIsGrounded();
            CheckIsRun();
        }

        private void CheckIsGrounded()
        {
            //if (_player.PlayerGravity.IsGrounded() != _currentIsGrounded)
            //{
            //    _currentIsGrounded = _player.PlayerGravity.IsGrounded();
            //    _animationSwitcher.UpdateIsGrounded(_currentIsGrounded);
            //}
        }

        private void CheckIsRun()
        {
            if (_player.Rigidbody.velocity.sqrMagnitude >= 0.001f && !_currentIsRun)
            {
                _currentIsRun = true;
                _animationSwitcher.StartRun();
            }
            else if (_player.Rigidbody.velocity.sqrMagnitude < 0.001f && _currentIsRun)
            {
                _currentIsRun = false;
                _animationSwitcher.EndRun();
            }
        }
    }
}
