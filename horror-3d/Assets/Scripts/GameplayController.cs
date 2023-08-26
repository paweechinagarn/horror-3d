using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Horror3D
{
    public class GameplayController : MonoBehaviour
    {
        public UnityEvent OnGameStarted;
        public UnityEvent OnGameEnded;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log($"Game starts");
            OnGameStarted?.Invoke();
        }

        public void Win()
        {
            Debug.Log($"You win!");
            End();
        }

        public void Lose()
        {
            Debug.Log($"You lose!");
            End();
        }

        private void End()
        {
            Time.timeScale = 0f;
            OnGameEnded?.Invoke();
        }
    }
}
