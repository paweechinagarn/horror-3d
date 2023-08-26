using UnityEngine;
using UnityEngine.Events;

namespace Horror3D
{
    public class EnemyController : MonoBehaviour
    {
        public UnityEvent OnCollidedWithPlayer;

        private bool isCollided;

        private void OnCollisionEnter(Collision collision)
        {
            if (isCollided)
                return;

            if (collision.gameObject.CompareTag(Tag.Player))
            {
                isCollided = true;
                OnCollidedWithPlayer?.Invoke();
            }
        }
    }
}
