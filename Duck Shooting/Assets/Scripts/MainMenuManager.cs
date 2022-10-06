//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] GameObject _controlPanel, _creditsPanel, _bgPanel;
        [SerializeField] SceneLoadManager _sceneLoadM;

        public void PlayGame()
        {
            StartCoroutine(_sceneLoadM.SceneLoad(2));
            GameManager.Instance.m_playPause = false;
            GameManager.Instance.m_isGameOver = false;
        }

        public void QuitGame()
        {
            GameManager.Instance.ExitGame();
        }

        public void OpenControls()
        {
            _controlPanel.SetActive(true);
            _bgPanel.SetActive(true);
        }

        public void CloseControls()
        {
            _controlPanel.SetActive(false);
            _bgPanel.SetActive(false);
        }

        public void OpenCredits()
        {
            _creditsPanel.SetActive(true);
            _bgPanel.SetActive(true);
        }

        public void CloseCredits()
        {
            _creditsPanel.SetActive(false);
            _bgPanel.SetActive(false);
        }

        public void OpenWebSite(string link)
        {
            Application.OpenURL(link);
        }
    }
}

