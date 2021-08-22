using System.Collections;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    private Animator _animator;
    private IMovingController _movingController;

    [SerializeField] AnimationClip JumpLandingRoll;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _movingController = GetComponent<IMovingController>();
    }

    public void Move(Transform body, Vector3 direction)
    {
        CalculateVerticalAndHorizontalValuesForLocomotion(body, direction, out float vertical, out float horizontal);
        
        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Horizontal", horizontal);
    }

    private void CalculateVerticalAndHorizontalValuesForLocomotion(Transform body, Vector3 direction, out float vertical, out float horizontal)
    {
        vertical = Vector3.Dot(body.forward, direction);

        float leftDot = Vector3.Dot(-body.right, direction);
        float rightDot = Vector3.Dot(body.right, direction);

        if (leftDot > rightDot)
            horizontal = -leftDot;
        else
            horizontal = rightDot;
    }

    public void StartJump()
    {
        _animator.SetBool("Jump", true);
        _movingController.ForbidMove();
    }

    public void EndJump()
    {
        _animator.SetBool("Jump", false);
        StartCoroutine(WaitJumpLandingRollAnimation());
    }

    private IEnumerator WaitJumpLandingRollAnimation()
    {
        yield return new WaitForSeconds(JumpLandingRoll.length);
        _movingController.AllowMove();
    }
}
