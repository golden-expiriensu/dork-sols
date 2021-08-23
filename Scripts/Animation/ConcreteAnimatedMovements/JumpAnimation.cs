public class JumpAnimation : BaseAnimatedMovement
{
    public JumpAnimation(
        UnityEngine.Animator animator,
        IAnimatedMovement animatedMovement
        )
        : base(
            animator, 
            animatedMovement,
            AnimationObserver.AnimationName.Jump
            ) 
    { }

    protected override void SetValueInAnimator(AnimationParameter parameter)
    {
        bool jumped = parameter.BoolValue;
        if (jumped)
        {
            parameter.MovingController.ForbidMove();
            _animator.SetBool("Jump", true); 
        }
        else
        {
            _animator.SetBool("Jump", false);
            WaitAnimationLenght(parameter.FloatValue, parameter.MovingController);
        }
    }

    private async void WaitAnimationLenght(float animationLenght, IMovingController movingController)
    {
        await System.Threading.Tasks.Task.Delay((int)(animationLenght * 1000));
        movingController.AllowMove();
    }
}
