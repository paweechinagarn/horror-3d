using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror3D
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement3D : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float turnSpeed = 10f;

        [field: SerializeField] public float MoveSpeed { get; set; }

        private Vector2 moveInput;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            MoveSpeed = walkSpeed;
        }

        private void FixedUpdate()
        {
            var cameraTransform = Camera.main.transform;

            // Calculate move direction
            var direction = cameraTransform.forward * moveInput.y + cameraTransform.right * moveInput.x;
            direction.y = 0f;

            // Move with walk speed or run speed
            characterController.Move(MoveSpeed * Time.fixedDeltaTime * direction);

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

        public void ResetSpeed()
        {
            MoveSpeed = walkSpeed;
        }
    }
}
