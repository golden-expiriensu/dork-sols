using UnityEngine;

namespace Player
{
    public class AnimationObserver : MonoBehaviour
    {
        private Link _player;
        private AnimationSwitcher _animationSwitcher;

        private void Awake()
        {
            _player = GetComponent<Link>();
            _animationSwitcher = GetComponent<AnimationSwitcher>();
        }

        private void Start()
        {
            _player.Jumper.OnPlayerJumped += _animationSwitcher.StartJump;
            _player.Jumper.OnPlayerLanded += _animationSwitcher.EndJump;
            _player.Control.OnGotAxisInput += _animationSwitcher.Move;
        }
    }
}
