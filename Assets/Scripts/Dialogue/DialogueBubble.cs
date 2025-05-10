using UnityEngine;

namespace Dialogue
{
    public class DialogueBubble : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0, 2f, 0);

        void Update()
        {
            if (target == null) return;

            Vector3 worldPos = target.position + offset;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            transform.position = screenPos;
        }
    }
}
