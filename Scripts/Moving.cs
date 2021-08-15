using UnityEngine;

public class Moving : MonoBehaviour
{
    private const float _moovingSpeed = 3f;

    private SurfaceSlider _surfaceSlider;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _surfaceSlider = GetComponent<SurfaceSlider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction);
        Vector3 offset = directionAlongSurface * _moovingSpeed * Time.deltaTime;
        Vector3 move = _rigidbody.position + offset;

        _rigidbody.MovePosition(move);
    }
}
