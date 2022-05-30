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
 
        [SerializeField] float _timeToStartMatch,_puBallSpeed, _puPSpeed, _puPSpeedAI,
            _puYBounds, _puPSize, _puBallSize, _pOneSpeed, _pOneYBound, _pTwoSpeed, _pTwoAISpeed, 
            _pTwoYBound, _pStartSize, _ballStartSize, _ballStartSpeed, _ballSpeedMult, _puBallSpeedMult;
        [SerializeField] GameObject[] _powerUps;
        [SerializeField] Ball _ballMov;
        [SerializeField] TMP_Text _p1ScoreText, _p2ScoreText, _p1FinalWScoreText, 
            _p1FinalLScoreText, _p2FinalWScoreText, _p2FinalLScoreText,_tieP1Score,
            _tieP2Score, _timerText;
        [SerializeField] PlayersMov _pOne, _pTwo;
        [SerializeField] GameObject _p1WinPanel, _p2WinPanel, _tiePanel, _pausePanel;
        [SerializeField] int _matchTime, _pwrUpInterval;
        
        int _p1Score, _p2Score, _currentTime, _rngPWRUp;
        float _timeStamp;
        bool _isTimeOut;
        Vector3 _rngPos;

        public bool m_p1ScoredGoal, m_p2ScoredGoal, m_pwrUpLaunch;
        AudioSource _highGong;

        //GameState: 0 -> Pause / 1 -> OnPlay
        public int m_gameState, 
            m_lastPlayer;
        
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
            InitialiseStats();
        }

        void Start()
        {
            Invoke(nameof(StartMatch), _timeToStartMatch);
            
            _p1WinPanel.SetActive(false);
            _p2WinPanel.SetActive(false);
            _tiePanel.SetActive(false);
            _isTimeOut = false;
            _currentTime = _matchTime;
            _timerText.text = _currentTime.ToString();
        }
         
        private void Update()
        {
            CountDownTimer();
            CheckGameState();
            LaunchPowerUps();

            if (Input.GetKeyDown(KeyCode.Escape) && m_gameState == 1)
            {
                PauseGame();
            }
 
        }

        void InitialiseStats()
        {
            _ballMov.m_ballSpeed = _ballStartSpeed;
            _ballMov.m_velocityMultiplier = _ballSpeedMult;

            _pOne.m_currentSpeed = _pOneSpeed;
            if (_pTwo.m_isAI) _pTwo.m_currentSpeed = _pTwoAISpeed;
            else _pTwo.m_currentSpeed = _pTwoSpeed;

            _pOne.m_currentYBound = _pOneYBound;
            _pTwo.m_currentYBound = _pTwoYBound;
        }

        void StartMatch()
        {
            _ballMov.AddStartingForce();
        }

        void CheckGameState()
        {
            //End of the Game:
            if (_p1Score == 10 || _p2Score == 10 || _isTimeOut) m_gameState = 0;
            else m_gameState = 1;

            if (m_gameState == 0)
            {
                //Show Winner Panel
                if (_p1Score == 10 )
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
                if (_isTimeOut && _p1Score > _p2Score)
                {
                    _p1WinPanel.SetActive(true);
                    _p1FinalWScoreText.text = _p1Score.ToString();
                    _p2FinalLScoreText.text = _p2Score.ToString();
                    _ballMov.LockMov();
                }
                if (_isTimeOut && _p1Score < _p2Score)
                {
                    _p2WinPanel.SetActive(true);
                    _p2FinalWScoreText.text = _p2Score.ToString();
                    _p1FinalLScoreText.text = _p1Score.ToString();
                    _ballMov.LockMov();
                }
                else if (_isTimeOut && _p1Score == _p2Score)
                {
                    //Empate
                    _tiePanel.SetActive(true);
                    _tieP1Score.text = _p1Score.ToString();
                    _tieP2Score.text = _p2Score.ToString();
                    _ballMov.LockMov();
                }
            }
        }

        void CountDownTimer()
        {
            //Timer Count Down
            if (Time.time - _timeStamp > 1 && _matchTime - 1 > -1)
            {
                _matchTime--;
                _timeStamp = Time.time;
                _currentTime = _matchTime;
                _timerText.text = _currentTime.ToString();
            }

            if (_matchTime == 0)
            {
                _isTimeOut = true;
            }
        }

        void LaunchPowerUps()
        {
            if (_currentTime % _pwrUpInterval == 0 && !m_pwrUpLaunch)
            {
                _rngPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-7.5f, 7.5f), -1);
                _rngPWRUp = Random.Range(0, 4);
                Instantiate(_powerUps[_rngPWRUp], _rngPos, Quaternion.Euler(90, 0, 0));
                m_pwrUpLaunch = true;
            }
        }

        #region PUBLIC METHODS

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

        public void ApplyPlayerSpeedPU()
        {
            if (m_lastPlayer == 1)
            {
                _pOne.m_currentSpeed = _puPSpeed;
            }
            else if (m_lastPlayer == 2)
            {
                if (_pTwo.m_isAI)
                {
                    _pTwo.m_currentSpeed = _puPSpeedAI;
                }
                else
                {
                    _pTwo.m_currentSpeed = _puPSpeed;
                }
            }
        }

        public void ApplyBallSpeedPU()
        {
            _ballMov.m_ballSpeed = _puBallSpeed;
            _ballMov.m_velocityMultiplier = _puBallSpeedMult;
        }
        
        public void ApplyPlayerSizePU()
        {
            if (m_lastPlayer == 1)
            {
                _pOne.m_currentYBound = _puYBounds;
                _pOne.gameObject.transform.localScale = new Vector3(1, _puPSize, 1);
            }
            else if (m_lastPlayer == 2)
            {
                _pTwo.m_currentYBound = _puYBounds;
                _pTwo.gameObject.transform.localScale = new Vector3(1, _puPSize, 1);
            }
        }

        public void ApplyBallSizePU()
        {
            _ballMov.gameObject.transform.localScale = new Vector3(_puBallSize, _puBallSize, _puBallSize);
        }

        public void RestorePlayersStats()
        {
            _pOne.m_currentSpeed = _pOneSpeed;

            if (_pTwo.m_isAI) _pTwo.m_currentSpeed = _pTwoAISpeed;
            else _pTwo.m_currentSpeed = _pTwoSpeed;


            _pOne.m_currentYBound = _pOneYBound;
            _pOne.gameObject.transform.localScale = new Vector3(1, _pStartSize, 1);
            _pTwo.m_currentYBound = _pTwoYBound;
            _pTwo.gameObject.transform.localScale = new Vector3(1, _pStartSize, 1);
        }

        public void RestoreBallStats()
        {
            _ballMov.m_ballSpeed = _ballStartSpeed;
            _ballMov.m_velocityMultiplier = _ballSpeedMult;
            _ballMov.gameObject.transform.localScale = new Vector3(_ballStartSize, _ballStartSize, _ballStartSize);
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

        public void RetryP1VsP2Game()
        {
            SceneManager.LoadScene(1);
        }

        public void RetryP1VsCPUGame()
        {
            SceneManager.LoadScene(2);
        }

        public void ReturnMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        #endregion

    }
}

