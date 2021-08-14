using UnityEngine;

namespace Player
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private float _moovingSpeed = 5f;
        public float MoovingSpeed
        {
            get
            {
                return _moovingSpeed;
            }
        }
    }
}
