using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror3D
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement3D : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float moveSpeed = 10f;

        private Vector2 moveInput;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            var cameraTransform = Camera.main.transform;
            var direction = cameraTransform.forward * moveInput.y + cameraTransform.right * moveInput.x;
            direction.y = 0f;
            characterController.Move(moveSpeed * Time.fixedDeltaTime * direction);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }
}
