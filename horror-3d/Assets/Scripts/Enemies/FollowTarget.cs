using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Horror3D
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float angleThreshold;

        [SerializeField] private Transform eye;
        [SerializeField] private Transform target;
        [SerializeField] private LayerMask layerMask;

        private readonly RaycastHit[] hitResults = new RaycastHit[10];

        private void Start()
        {
            agent.isStopped = true;
        }

        private void Update()
        {
            if (target == null)
                return;

            var angle = Vector3.Angle(transform.position - target.position, Camera.main.transform.forward);
            if (Mathf.Abs(angle) > angleThreshold)
            {
                Follow();
                return;
            }

            var cameraPosition = Camera.main.transform.position;
            var direction = cameraPosition - eye.position;
            direction.y = 0f;
            var hits = Physics.RaycastNonAlloc(eye.position, direction, hitResults, direction.magnitude, layerMask);
            if (hits == 0)
            {
                Unfollow();
            }
            else
            {
                Follow();
            }
        }

        public void Follow()
        {
            if (target == null)
                return;

            if (!agent.enabled)
                return;

            if (agent.isStopped)
                Debug.Log($"{name} is following!");

            agent.isStopped = false;
            agent.SetDestination(target.position);
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
