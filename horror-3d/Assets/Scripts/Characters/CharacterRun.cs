using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace Horror3D
{
    public class CharacterRun : MonoBehaviour
    {
        [SerializeField] private CharacterMovement3D characterMovement;
        [SerializeField] private float runSpeed = 10f;

        private bool isRunning;

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.interaction is not HoldInteraction)
                return;

            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    isRunning = true;
                    characterMovement.MoveSpeed = runSpeed;
                    break;
                case InputActionPhase.Canceled:
                    characterMovement.ResetSpeed();
                    isRunning = false;
                    break;
            }
        }
    }
}
