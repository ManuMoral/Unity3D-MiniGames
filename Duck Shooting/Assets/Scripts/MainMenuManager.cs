//Exercise 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] GameObject _controlPanel, _creditsPanel;

        public void PlayGame()
        {
            GameManager.Instance.LoadGamePlayScene();
            GameManager.Instance.m_playPause = false;
        }

        public void QuitGame()
        {
            GameManager.Instance.ExitGame();
        }

        public void OpenControls()
        {
            _controlPanel.SetActive(true);
        }

        public void CloseControls()
        {
            _controlPanel.SetActive(false);
        }

        public void OpenCredits()
        {
            _creditsPanel.SetActive(true);
        }

        public void CloseCredits()
        {
            _creditsPanel.SetActive(false);
        }

        public void OpenWebSite(string link)
        {
            Application.OpenURL(link);
        }
    }
}

