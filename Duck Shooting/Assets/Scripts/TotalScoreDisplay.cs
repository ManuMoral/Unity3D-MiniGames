//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class TotalScoreDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _ducksKilledText, _maxPxDuckText, _maxTimeEarnText, _totalRDText, _totalSDText, _totalVDText, _totalDDText;
        [SerializeField] SceneLoadManager _sceneLoadM;
        [SerializeField, TextArea(2,5)] string _urlText, _webText, _twtPrompt1, _twtPrompt2;

        private void Start()
        {
            DisplayRecords();
        }

        private void DisplayRecords()
        {
            _ducksKilledText.text = GameManager.Instance.m_newScore.ToString();
            _maxPxDuckText.text = GameManager.Instance.m_maxPxDuck.ToString();
            _maxTimeEarnText.text = GameManager.Instance.m_maxTimeEarn.ToString();
            _totalRDText.text = GameManager.Instance.m_totalRD.ToString();
            _totalSDText.text = GameManager.Instance.m_totalSD.ToString();
            _totalVDText.text = GameManager.Instance.m_totalVD.ToString();
            _totalDDText.text = GameManager.Instance.m_totalDD.ToString();
        }

        public void GoToMainMenu()
        {
            GameManager.Instance.m_playPause = false;
            GameManager.Instance.m_isGameOver = true;
            StartCoroutine(_sceneLoadM.SceneLoad(1));
        } 

        public void RetryGame()
        {
            GameManager.Instance.m_playPause = false;
            GameManager.Instance.m_isGameOver = false;
            StartCoroutine(_sceneLoadM.SceneLoad(2));
        }   

        public void QuitGame()
        {
            GameManager.Instance.ExitGame();
        }

        public void ShareScoreOnTwitter()
        {
            Application.OpenURL(_urlText 
                + _webText 
                + _twtPrompt1 
                + GameManager.Instance.m_newScore.ToString() + "%20Points"
                + "%0A" + GameManager.Instance.m_totalRD.ToString() + "%20RubberDucks"
                + "%0A" + GameManager.Instance.m_totalSD.ToString() + "%20SuperDucks"
                + "%0A" + GameManager.Instance.m_totalVD.ToString() + "%20VampiDucks"
                + "%0A" + GameManager.Instance.m_totalDD.ToString() + "%20DracuDucks"
                + "%0A" + GameManager.Instance.m_maxPxDuck.ToString() + "%20MaxPTSxDuck"
                + "%0A" + GameManager.Instance.m_maxTimeEarn.ToString() + "%20ExtraTimeEarn"
                + _twtPrompt2);
        }
    }
}

