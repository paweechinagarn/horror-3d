using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror3D
{
    public class CharacterInteraction : MonoBehaviour
    {
        private readonly HashSet<Transform> interactables = new HashSet<Transform>();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IInteractable>(out _))
                return;

            interactables.Add(other.transform);
            Debug.Log($"Add {other.name}");
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<IInteractable>(out _))
                return;

            interactables.Remove(other.transform);
            Debug.Log($"Remove {other.name}");
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            if (interactables.Count == 0)
                return;

            if (interactables.Count == 1)
            {
                Interact(interactables.First());
                return;
            }

            var sortedInteractables = interactables.OrderBy(x =>
                Vector3.Angle(x.position - transform.position, Camera.main.transform.forward) + 
                Vector3.Magnitude(x.position - transform.position));

            Interact(sortedInteractables.First());
        }

        private void Interact(Transform interactableTransform)
        {
            var interactable = interactableTransform.GetComponent<IInteractable>();
            if (interactable.AmountMode == InteractionAmountMode.Once) interactables.Remove(interactableTransform);
            interactable.Interact();
        }
    }
}
