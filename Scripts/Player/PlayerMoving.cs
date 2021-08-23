using UnityEngine;

public class PlayerMoving : Moving
{
    private const float _moovingSpeed = 3f;

    private SurfaceSlider _surfaceSlider;
    private CharacterController _controller;

    [SerializeField] private Transform _model;

    private void Awake()
    {
        _surfaceSlider = GetComponent<SurfaceSlider>();
        _controller = GetComponent<CharacterController>();
    }


    public void Move(Vector3 targetDirection)
    {
        if (targetDirection != Vector3.zero)
        {
            Vector3 clampedDirection = Vector3.ClampMagnitude(targetDirection, 1);
            Vector3 directionAlongSurface = _surfaceSlider.Project(clampedDirection);

            _controller.Move(directionAlongSurface * _moovingSpeed * Time.deltaTime);
        }
        
        UpdateMoveEvent(_model, Vector3.ClampMagnitude(targetDirection, 1));
    }
}
