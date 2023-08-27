using TMPro;
using UnityEngine;

namespace Horror3D
{
    public class PostGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private string winText;
        [SerializeField] private string loseText;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetResult(bool isWinning)
        {
            resultText.text = isWinning ? winText : loseText;
            gameObject.SetActive(true);
        }
    }
}
