using UnityEngine;

namespace Player
{
    public class Link : MonoBehaviour
    {
        public Moving Moving { get; private set; }
        public Jumping Tricks { get; private set; }
        public Rotating Rotating { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public GroundCheck GroundCheck { get; private set; }
        public Stats Stats { get; private set; }
        [SerializeField] Transform model;
        public Transform Model 
        {
            get
            {
                return model;
            }
        }

        [SerializeField] private Transform cameraTransform;
        public Transform CameraTransform
        {
            get { return cameraTransform; }
        }


        private void Awake()
        {
            Moving = GetComponent<Moving>();
            Tricks = GetComponent<Jumping>();
            Rotating = GetComponent<Rotating>();
            Rigidbody = GetComponent<Rigidbody>();
            GroundCheck = GetComponent<GroundCheck>();
            Stats = GetComponent<Stats>();
        }
    }
}
