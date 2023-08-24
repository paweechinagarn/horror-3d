using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace Horror3D
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement3D : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float runSpeed = 10f;
        [SerializeField] private float turnSpeed = 10f;

        private Vector2 moveInput;
        private bool isRunning;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            var cameraTransform = Camera.main.transform;

            // Calculate move direction
            var direction = cameraTransform.forward * moveInput.y + cameraTransform.right * moveInput.x;
            direction.y = 0f;

            // Move with walk speed or run speed
            characterController.Move((isRunning ? runSpeed : walkSpeed) * Time.fixedDeltaTime * direction);

            // Looking towards move direction
            if (direction != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.fixedDeltaTime);
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.interaction is not HoldInteraction)
                return;

            Debug.Log($"hold shift {context.phase}");
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    isRunning = true;
                    break;
                case InputActionPhase.Canceled:
                    isRunning = false;
                    break;
            }
            Debug.Log($"isRunning = {isRunning}");
        }
    }
}
