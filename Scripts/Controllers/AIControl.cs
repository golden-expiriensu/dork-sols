using System.Collections;
using UnityEngine;

public class AIControl : MovingControl
{
    private AIMoving _aiMoving;

    //TODO: delete both
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _model;

    private void Awake()
    {
        _aiMoving = GetComponent<AIMoving>();
    }

    private void Start()
    {
        StartCoroutine(LazyFinding());
    }

    private IEnumerator LazyFinding()
    {
        _aiMoving.Move(_player.position);
        yield return new WaitForSeconds(3);
        StartCoroutine(LazyFinding());
    }
}
