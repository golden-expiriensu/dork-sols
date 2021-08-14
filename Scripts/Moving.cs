using UnityEngine;

namespace Player
{
    public class Moving : MonoBehaviour
    {
        private Link _player;
        private SurfaceSlider _surfaceSlider;

        private void Awake()
        {
            _player = GetComponent<Link>();
            _surfaceSlider = GetComponent<SurfaceSlider>();
        }

        public void Move(Vector3 direction)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction);
            Vector3 offset = directionAlongSurface * _player.Stats.MoovingSpeed * Time.deltaTime;
            Vector3 move = _player.Rigidbody.position + offset;
            
            _player.Rigidbody.MovePosition(move);
        }
    }
}
