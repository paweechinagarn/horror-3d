using UnityEngine;
using UnityEngine.Events;

namespace Horror3D
{
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent OnTriggerEntered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tag.Player)) OnTriggerEntered?.Invoke();
        }
    }
}
