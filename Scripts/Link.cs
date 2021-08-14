using UnityEngine;

namespace Player
{
    public class Link : MonoBehaviour
    {
        public Control Control { get; private set; }
        public Moving Moving { get; private set; }
        public Jumping Jumper { get; private set; }
        public Rotating Rotating { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public GroundCheck GroundCheck { get; private set; }

        [SerializeField] private Transform cameraTransform;
        public Transform CameraTransform
        {
            get { return cameraTransform; }
        }


        private void Awake()
        {
            Control = GetComponent<Control>();
            Moving = GetComponent<Moving>();
            Jumper = GetComponent<Jumping>();
            Rotating = GetComponent<Rotating>();
            Rigidbody = GetComponent<Rigidbody>();
            GroundCheck = GetComponent<GroundCheck>();
        }
    }
}
