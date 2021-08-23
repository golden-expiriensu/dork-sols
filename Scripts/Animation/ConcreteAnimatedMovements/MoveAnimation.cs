using UnityEngine;

public class MoveAnimation : BaseAnimatedMovement
{
    public MoveAnimation(
        Animator animator,
        IAnimatedMovement animatedMovement
        ) 
        : base(
            animator,
            animatedMovement,
            AnimationObserver.AnimationName.Move) { }

    protected override void SetValueInAnimator(AnimationParameter parameter)
    {
        ConvertMovingDirectionToAxis(
            parameter.TransformValue, 
            parameter.VectorValue,
            out float vertical,
            out float horizontal
            );

        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Horizontal", horizontal);
    }

    private void ConvertMovingDirectionToAxis(Transform body, Vector3 direction, out float vertical, out float horizontal)
    {
        vertical = Vector3.Dot(body.forward, direction);

        float leftHorizontal = Vector3.Dot(-body.right, direction);
        float rightHorizontal = Vector3.Dot(body.right, direction);

        if (leftHorizontal > rightHorizontal)
            horizontal = -leftHorizontal;
        else
            horizontal = rightHorizontal;
    }
}
