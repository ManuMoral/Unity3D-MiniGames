//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class ScoreCalculator : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _ducksKilledText;
        
        int m_currentScore;
        public int m_diffState;

        private void Start()
        {
            m_diffState = 0;
        }

        private void Update()
        {
            //Difficulty levels:
            if (m_currentScore > 10 && m_currentScore <= 20)
            {
                m_diffState = 1;
            }
            else if(m_currentScore > 21 && m_currentScore <= 30)
            {
                m_diffState = 2;
            }
            else if (m_currentScore > 31 && m_currentScore <= 50)
            {
                m_diffState = 3;
            }
            else if (m_currentScore > 51)
            {
                m_diffState = 4;
            }
            else
            {
                m_diffState = 0;
            }

        }

        public void KillDuck() 
        {
            m_currentScore += 1;
            UpdateScore();
        }

        public void KillVampiDuck()
        {
            m_currentScore -= 5;
            if (m_currentScore <= 0) m_currentScore = 0;
            UpdateScore();
        }

        public void KillSuperDuck()
        {
            m_currentScore += 5;
            UpdateScore();
        }

        void UpdateScore()
        {
            _ducksKilledText.text = m_currentScore.ToString();
            GameManager.Instance.m_newScore = m_currentScore;
        }
    }
}

