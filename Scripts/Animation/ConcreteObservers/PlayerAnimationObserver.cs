using System.Collections;
using UnityEngine;

public class PlayerAnimationObserver : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    //
    private Moving _moving;
    [SerializeField] private Transform _model;
    //
    private Jumping _jumping;
    private IMovingController _movingController;
    [SerializeField] private AnimationClip _landingAnimation;
    //
    private IAnimatedMovement _animationController;

    private void Awake()
    {
        _moving = GetComponent<Moving>();
        _jumping = GetComponent<Jumping>();
        _movingController = GetComponent<IMovingController>();

        _animationController = new MoveAnimation(_animator, null);
        _animationController = new JumpAnimation(_animator, _animationController);

        _moving.OnMoved += MoveEvent;
        _jumping.OnJumped += JumpEvent;
        _jumping.OnLanded += LandEvent;
    }

    private void MoveEvent(Transform body, Vector3 direction)
    {
        _animationController.StartAnimation(AnimationObserver.AnimationName.Move, new AnimationParameter(body, direction));
    }
    private void JumpEvent()
    {
        _animationController.StartAnimation(AnimationObserver.AnimationName.Jump, new AnimationParameter(true, _landingAnimation.length, _movingController));
    }
    private void LandEvent()
    {
        _animationController.StartAnimation(AnimationObserver.AnimationName.Jump, new AnimationParameter(false, _landingAnimation.length, _movingController));
    }
}
