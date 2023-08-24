using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace Horror3D
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterCrouch : MonoBehaviour
    {
        private enum CrouchingState
        {
            Stand,
            Crouch,
            PrepareToStand
        }

        [SerializeField] private CharacterController characterController;
        [SerializeField] private CharacterMovement3D characterMovement;
        [SerializeField] private float crouchSpeed;
        [SerializeField] private float crouchingHeight;
        [SerializeField] private float standingHeight;
        [SerializeField] private LayerMask obstacleLayerMask;

        private CrouchingState state;
        private readonly RaycastHit[] checkHeadResult = new RaycastHit[1];

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (state != CrouchingState.PrepareToStand)
                return;

            var hits = Physics.RaycastNonAlloc(transform.position, Vector3.up, checkHeadResult, standingHeight, obstacleLayerMask);
            if (hits == 0)
            {
                Stand();
            }
        }


        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.interaction is not HoldInteraction)
                return;

            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    Crouch();
                    break;
                case InputActionPhase.Canceled:
                    state = CrouchingState.PrepareToStand;
                    break;
            }
        }

        private void Crouch()
        {
            state = CrouchingState.Crouch;
            characterController.height = crouchingHeight;
            characterController.center = new Vector3(characterController.center.x, crouchingHeight * 0.5f, characterController.center.z);
            characterMovement.MoveSpeed = crouchSpeed;
        }

        private void Stand()
        {
            characterController.height = standingHeight;
            characterController.center = new Vector3(characterController.center.x, standingHeight * 0.5f, characterController.center.z);
            characterMovement.ResetSpeed();
            state = CrouchingState.Stand;
        }
    }
}
