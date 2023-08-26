using UnityEngine;
using UnityEngine.AI;

namespace Horror3D
{
    public class PlaySoundOnMove : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        [SerializeField] private NavMeshAgent agent;

        private void Update()
        {
            if (agent.velocity != Vector3.zero && !source.isPlaying)
            {
                source.Play();
            }
            else if (agent.velocity == Vector3.zero && source.isPlaying)
            {
                source.Stop();
            }
        }
    }
}
