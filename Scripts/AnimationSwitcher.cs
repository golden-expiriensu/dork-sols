using System.Collections;
using UnityEngine;

namespace Player
{
    public class AnimationSwitcher : MonoBehaviour
    {
        private Animator _animator;
        private Link _player;

        [SerializeField] AnimationClip JumpLandingRoll;

        private void Awake()
        {
            _player = GetComponent<Link>();
            _animator = GetComponentInChildren<Animator>();
        }

        public void Move(float vertical, float horizontal)
        { 
            _animator.SetFloat("Vertical", vertical);
            _animator.SetFloat("Horizontal", horizontal);
        }

        public void StartJump()
        {
            _animator.SetBool("Jump", true);
            _player.Control.CanMove = false;
        }
        
        public void EndJump()
        {
            _animator.SetBool("Jump", false);
            StartCoroutine(WaitJumpLandingRollAnimation());
        }

        private IEnumerator WaitJumpLandingRollAnimation()
        {
            yield return new WaitForSeconds(JumpLandingRoll.length);
            _player.Control.CanMove = true;
        }
    }
}
