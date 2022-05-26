//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Unity3DMiniGames
{
    public class MatchManager : MonoBehaviour
    {
        #region PROPERTIES (DATA)

        [SerializeField] float _timeToStartMatch;
        
        [SerializeField] Ball _ballMov;
        [SerializeField] TMP_Text _p1ScoreText, _p2ScoreText, _p1FinalWScoreText, 
            _p1FinalLScoreText, _p2FinalWScoreText, _p2FinalLScoreText;
        [SerializeField] PlayersMov _pOne, _pTwo;
        [SerializeField] GameObject _p1WinPanel, _p2WinPanel, _pausePanel;

        int _p1Score, _p2Score;
        public bool m_p1ScoredGoal, m_p2ScoredGoal;
        AudioSource _highGong;

        //GameState: 0 -> Pause / 1 -> OnPlay
        public int m_gameState;
        
        //GameMode:
        //0 : Human Vs Human
        //1 : Human Vs IA
        //2 : 4 Humans
        public int m_gameMode;

        #endregion

        private void Awake()
        {
            _highGong = GetComponent<AudioSource>();
            m_gameState = 1;
        }

        void Start()
        {
            Invoke(nameof(StartMatch), _timeToStartMatch);
            _p1WinPanel.SetActive(false);
            _p2WinPanel.SetActive(false);
        }
         
        private void Update()
        {
            if (_p1Score == 10 || _p2Score == 10) m_gameState = 0;
            else m_gameState = 1;

            if (m_gameState == 0)
            {
                //Show Winner Panel
                if (_p1Score == 10)
                {
                    _p1WinPanel.SetActive(true);
                    _p1FinalWScoreText.text = _p1Score.ToString();
                    _p2FinalLScoreText.text = _p2Score.ToString();
                }
                if (_p2Score == 10)
                {
                    _p2WinPanel.SetActive(true);
                    _p2FinalWScoreText.text = _p2Score.ToString();
                    _p1FinalLScoreText.text = _p1Score.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && m_gameState == 1)
            {
                PauseGame();
            }
        }

        public void PlayerOneScored()
        {
            _p1Score++;
            _p1ScoreText.text = _p1Score.ToString();
            m_p2ScoredGoal = false;
            m_p1ScoredGoal = true;
            _highGong.Play();
        }

        public void PlayerTwoScored()
        {
            _p2Score++;
            _p2ScoreText.text = _p2Score.ToString();
            m_p1ScoredGoal = false;
            m_p2ScoredGoal = true;
            _highGong.Play();
        }

        public void RestartPoint()
        {
            _pOne.gameObject.transform.position = new Vector3(-17, 0, - 1);
            _pTwo.gameObject.transform.position = new Vector3(17, 0, -1);
            _ballMov.gameObject.transform.position = new Vector3(0, 0, -.9f);
        }

        public void PauseGame()
        {
            m_gameState = 0;
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            m_gameState = 1;
            _pausePanel.SetActive(false);
        }

        public void RetryGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ReturnMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        void StartMatch()
        {
            _ballMov.AddStartingForce();
        }
    }
}

