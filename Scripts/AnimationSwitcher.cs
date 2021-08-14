using System.Collections;
using UnityEngine;

namespace Player
{
    public class AnimationSwitcher : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void StartRun()
        {
            _animator.SetBool("Run", true);
        }

        public void EndRun()
        {
            _animator.SetBool("Run", false);
        }

        public void StartJump()
        {
            _animator.SetBool("Jump", true);
        }
        
        public void EndJump()
        {
            _animator.SetBool("Jump", false);
        }

        public void UpdateIsGrounded(bool IsGrounded)
        {
            _animator.SetBool("IsGrounded", IsGrounded);
            if (IsGrounded) EndJump();
        }
    }
}
