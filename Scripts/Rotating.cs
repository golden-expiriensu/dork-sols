using UnityEngine;

namespace Player
{
    public class Rotating : MonoBehaviour
    {
        private Link _player;
        [SerializeField] private Transform _model;

        private void Awake()
        {
            _player = GetComponent<Link>();
        }

        public void RotateTransformForwardCamera()
        {
            float yDifference = _player.CameraTransform.eulerAngles.y - transform.eulerAngles.y;
            _model.rotation = Quaternion.Euler(0, yDifference, 0);
        }
    }
}