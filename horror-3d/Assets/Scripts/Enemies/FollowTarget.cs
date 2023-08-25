using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Horror3D
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        public Transform Eye;
        public Transform Target;

        private readonly RaycastHit[] hitResults = new RaycastHit[10];

        private void Update()
        {
            var direction = Target.position - Eye.position;
            direction.y = 0f;

            Debug.DrawRay(Eye.position, direction);

            var hits = Physics.RaycastNonAlloc(Eye.position, direction, hitResults);
            if (hits == 0)
                return;

            var sortedHitResults = hitResults.Where(x => x.transform != null).OrderBy(x => x.distance);

            var firstHitResult = sortedHitResults.First();
            if (firstHitResult.transform == Target)
            {
                agent.SetDestination(Target.position);
            }
        }
    }
}
