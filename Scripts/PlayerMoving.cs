using UnityEngine;

public class PlayerMoving : Moving
{
    private const float _moovingSpeed = 3f;

    private SurfaceSlider _surfaceSlider;
    private Rigidbody _rigidbody;

    [SerializeField] private Transform _model;

    private void Awake()
    {
        _surfaceSlider = GetComponent<SurfaceSlider>();
        _rigidbody = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 targetDirection)
    {
        if (targetDirection != Vector3.zero)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(targetDirection);
            Vector3 offset = directionAlongSurface * _moovingSpeed * Time.deltaTime;
            Vector3 move = _rigidbody.position + offset;

            _rigidbody.MovePosition(move); 
        }

        UpdateMoveEvent(_model, Vector3.ClampMagnitude(targetDirection, 1));
    }
}
