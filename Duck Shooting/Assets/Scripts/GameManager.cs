//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class GameManager : MonoBehaviour
    {
        public int m_newScore, m_maxPxDuck, m_maxTimeEarn, m_totalRD, m_totalSD, m_totalVD, m_totalDD;
        public bool m_playPause, m_speedShootBonusOn, m_isGameOver, m_isSoundOff, m_isFirstTrans;
        [SerializeField] float _timeToTurnOnTheScene;

        //Singleton structure:
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        private void Awake()
        {
            //Singleton structure:
            if (instance == null) instance = this;
            else Destroy(gameObject);
            DontDestroyOnLoad(this);

            m_playPause = false;
            m_isSoundOff = false;
            m_isFirstTrans = true;
        }

        public static void ResetScores()
        {
            Instance.m_newScore = 0;
            Instance.m_maxPxDuck = 1;
            Instance.m_maxTimeEarn = 0;
            Instance.m_totalRD = 0;
            Instance.m_totalSD = 0;
            Instance.m_totalVD = 0;
            Instance.m_totalDD = 0;
        }

        public static void PauseGame()
        {
            Time.timeScale = 0;
            Instance.m_playPause = true;
        }

        public static void ResumeGame()
        {
            Time.timeScale = 1;
            Instance.m_playPause = false;
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void TurnOnTheScene()
        {
            Invoke(nameof(UnPauseScene), _timeToTurnOnTheScene);
        }

        void UnPauseScene()
        {
            Instance.m_playPause = false;
        }

    }
}

