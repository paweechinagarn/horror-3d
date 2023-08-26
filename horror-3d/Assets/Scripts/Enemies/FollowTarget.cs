using UnityEngine;
using UnityEngine.AI;

namespace Horror3D
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Renderer enemyRenderer;
        [SerializeField] private float angleThreshold;

        public Transform Eye;
        public Transform Target;

        private void Update()
        {
            if (Target == null)
                return;

            var angle = Vector3.Angle(transform.position - Target.position, Camera.main.transform.forward);
            if (!enemyRenderer.isVisible || Mathf.Abs(angle) > angleThreshold)
            {
                Follow();
            }
            else
            {
                Unfollow();
            }
        }

        public void Follow()
        {
            if (Target == null)
                return;

            agent.isStopped = false;
            agent.SetDestination(Target.position);
            Debug.Log($"{name} is following!");
        }

        public void Unfollow()
        {
            agent.isStopped = true;
        }
    }
}
