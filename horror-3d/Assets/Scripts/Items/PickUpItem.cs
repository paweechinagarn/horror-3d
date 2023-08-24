using UnityEngine;

namespace Horror3D
{
    public class PickUpItem : MonoBehaviour, IInteractable
    {
        public InteractionAmountMode AmountMode => InteractionAmountMode.Once;

        public void Interact()
        {
            Debug.Log($"{name} has been picked up.");
            Destroy(gameObject);
        }
    }
}
