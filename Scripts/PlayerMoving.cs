using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private const float _moovingSpeed = 3f;

    private SurfaceSlider _surfaceSlider;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _surfaceSlider = GetComponent<SurfaceSlider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 targetDirection)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(targetDirection);
        Vector3 offset = directionAlongSurface * _moovingSpeed * Time.deltaTime;
        Vector3 move = _rigidbody.position + offset;

        _rigidbody.MovePosition(move);
    }
}
