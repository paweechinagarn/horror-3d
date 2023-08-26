using UnityEngine;
using UnityEngine.Events;

namespace Horror3D
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        public UnityEvent OnInteracted;

        public InteractionAmountMode AmountMode => InteractionAmountMode.Once;

        public void Interact()
        {
            OnInteracted?.Invoke();
        }
    }
}
