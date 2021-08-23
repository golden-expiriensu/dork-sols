public abstract class BaseAnimatedMovement : AnimationStarter, IAnimatedMovement
{
    private AnimationObserver.AnimationName _name;
    private IAnimatedMovement _animatedMovement;

    public BaseAnimatedMovement(
        UnityEngine.Animator animator,
        IAnimatedMovement animatedMovement,
        AnimationObserver.AnimationName name
        ) 
        : base(animator)
    {
        _animatedMovement = animatedMovement;
        _name = name;
    }

    public bool StartAnimation(AnimationObserver.AnimationName name, AnimationParameter parameter = null)
    {
        if (name == _name)
        {
            SetValueInAnimator(parameter);
            return true;
        }
        else if(_animatedMovement == null)
        {
            return false;
        }
        else
        {
            return _animatedMovement.StartAnimation(name, parameter);
        }
    }

    protected abstract void SetValueInAnimator(AnimationParameter parameter);
}
