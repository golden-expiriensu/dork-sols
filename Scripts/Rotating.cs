using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _model;

    public void RotateByDifferenceInRotating(Transform betweenThisTransform, Transform andThis)
    {
        float yDifference = betweenThisTransform.eulerAngles.y - andThis.eulerAngles.y;
        _model.rotation = Quaternion.Euler(0, yDifference, 0);
    }
}