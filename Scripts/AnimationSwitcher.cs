﻿using System.Collections;
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

    public void Move(float vertical, float horizontal)
    {
        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Horizontal", horizontal);
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
