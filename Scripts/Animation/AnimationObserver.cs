using UnityEngine;

public class AnimationObserver : MonoBehaviour
{
    private Jumping _jumping;
    private AnimationSwitcher _animationSwitcher;
    private Moving _moving;

    private void Awake()
    {
        _jumping = GetComponent<Jumping>();
        _animationSwitcher = GetComponent<AnimationSwitcher>();
        _moving = GetComponent<Moving>();
    }

    private void Start()
    {
        _jumping.OnJumped += _animationSwitcher.StartJump;
        _jumping.OnLanded += _animationSwitcher.EndJump;
        _moving.OnMoved += _animationSwitcher.Move;
    }
}
