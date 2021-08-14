using UnityEngine;

namespace Player
{
    public class Rotating : MonoBehaviour
    {
        [SerializeField] private float Turn90Speed = 0.03f;

        public void TurnLeft()
        {
            Quaternion turn = Quaternion.Euler(0, -90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * turn, Turn90Speed);
        }

        public void TurnRight()
        {
            Quaternion turn = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * turn, Turn90Speed);
        }
    }
}