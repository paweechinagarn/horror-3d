using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Horror3D
{

    public class GameplayController : MonoBehaviour
    {
        public UnityEvent OnGameStarted;
        public UnityEvent<bool> OnGameEnded;

        private IEnumerator Start()
        {
            Time.timeScale = 1f;
            yield return new WaitForSeconds(1f);
            Debug.Log($"Game starts");
            OnGameStarted?.Invoke();
        }

        public void Win()
        {
            Debug.Log($"You win!");
            Time.timeScale = 0f;
            OnGameEnded?.Invoke(true);
        }

        public void Lose()
        {
            Debug.Log($"You lose!");
            Time.timeScale = 0f;
            OnGameEnded?.Invoke(false);
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
