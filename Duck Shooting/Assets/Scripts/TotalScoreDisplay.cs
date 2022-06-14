//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class TotalScoreDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _ducksKilledText;

        private void Start()
        {
            _ducksKilledText.text = GameManager.Instance.m_newScore.ToString();
        }

        public void GoToMainMenu()
        {
            GameManager.Instance.LoadMainMenuScene();
            GameManager.Instance.m_playPause = false;
        } 

        public void RetryGame()
        {
            GameManager.Instance.LoadGamePlayScene();
            GameManager.Instance.m_playPause = false;
        }

        public void QuitGame()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

