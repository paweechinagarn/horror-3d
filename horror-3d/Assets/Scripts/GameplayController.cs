using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror3D
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            playerInput.enabled = true;
            Debug.Log($"Game starts");
        }
    }
}
