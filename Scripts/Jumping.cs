using System;
using System.Collections;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpLength;
    [SerializeField] private AnimationCurve _jumpHeightCurve;
    public Action OnJumped;
    public Action OnLanded;

    public void Jump(Vector3 direction)
    {
        OnJumped?.Invoke();
        StartCoroutine(AnimateJump(direction));
    }

    private IEnumerator AnimateJump(Vector3 direction)
    {
        float elapsedTime = 0f;
        float jumpProgress = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + direction * _jumpLength;

        while (jumpProgress < 1f)
        {
            elapsedTime += Time.deltaTime;
            jumpProgress = elapsedTime / _jumpDuration;

            Vector3 move = CalculateJumpPositionByTime(jumpProgress, startPosition, targetPosition);
            transform.position = move;

            yield return null;
        }

        OnLanded?.Invoke();
    }

    private Vector3 CalculateJumpPositionByTime(float jumpProgress, Vector3 startPosition, Vector3 targetPosition)
    {
        float yOffset = _jumpHeightCurve.Evaluate(jumpProgress) * _jumpHeight;
        float y = startPosition.y + yOffset;
        Vector3 xz = Vector3.Lerp(startPosition, targetPosition, jumpProgress);

        Vector3 move = new Vector3(xz.x, y, xz.z);

        return move;
    }
}
