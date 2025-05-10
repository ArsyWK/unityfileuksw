using UnityEngine;

namespace Utility
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        [SerializeField, Range(0,1)] public float smoothTime = 0.2f;
        public Vector3 offset = new Vector3(0, 0, -10f);
        private Vector3 _velocity = Vector3.zero;

        private void Update()
        {
            Vector3 targetPos = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTime);
        }
    }
}
