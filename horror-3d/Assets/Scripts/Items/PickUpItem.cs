using UnityEngine;
using UnityEngine.Events;

namespace Horror3D
{
    public class PickUpItem : MonoBehaviour, IInteractable
    {
        public UnityEvent OnPickedUp;

        public InteractionAmountMode AmountMode => InteractionAmountMode.Once;

        public void Interact()
        {
            Debug.Log($"{name} has been picked up.");
            OnPickedUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
