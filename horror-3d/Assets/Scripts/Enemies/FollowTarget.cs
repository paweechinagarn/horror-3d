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

        private void Start()
        {
            agent.isStopped = true;
        }

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

            if (!agent.enabled)
                return;

            if (agent.isStopped)
                Debug.Log($"{name} is following!");

            agent.isStopped = false;
            agent.SetDestination(Target.position);
        }

        public void Unfollow()
        {
            if (!agent.enabled)
                return;

            if (!agent.isStopped)
                Debug.Log($"{name} is stop following!");

            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }

        public void Stop()
        {
            if (!agent.enabled)
                return;

            Unfollow();
            agent.enabled = false;
        }
    }
}
