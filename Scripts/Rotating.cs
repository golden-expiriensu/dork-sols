using UnityEngine;

namespace Player
{
    public class Rotating : MonoBehaviour
    {
        private Link _player;

        private void Awake()
        {
            _player = GetComponent<Link>();
        }

        public void RotatePlayerForwardCamera()
        {
            float yDifference = _player.CameraTransform.eulerAngles.y - transform.eulerAngles.y;
            _player.Model.rotation = Quaternion.Euler(0, yDifference, 0);
        }
    }
}