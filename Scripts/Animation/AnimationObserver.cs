using UnityEngine;

public class AnimationObserver : MonoBehaviour
{
    private Jumping _jumping;
    private AnimationSwitcher _animationSwitcher;
    private IMovingController _movingController;

    private void Awake()
    {
        _jumping = GetComponent<Jumping>();
        _animationSwitcher = GetComponent<AnimationSwitcher>();
        _movingController = GetComponent<IMovingController>();
    }

    private void Start()
    {
        _jumping.OnJumped += _animationSwitcher.StartJump;
        _jumping.OnLanded += _animationSwitcher.EndJump;
        _movingController.SubscribeOnAxisInput(_animationSwitcher.Move);
    }
}
