//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class ScoreCalculator : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _ducksKilledText, _totalBonusPoints;
        [SerializeField] int _duckPoints;
        int currentScore, bonusDuckPoints;
        public int m_diffState;

        private void Start()
        {
            m_diffState = 0;
            bonusDuckPoints = 0;
            UpdateScore();
            BalloonEvent.SetBonus += ApplyBonusPoints;
        }

        private void Update()
        {
            DifficultySeter();
        }

        private void DifficultySeter()
        {
            //Difficulty levels:
            if (currentScore > 10 && currentScore <= 50)
            {
                m_diffState = 1;
            }
            else if (currentScore > 51 && currentScore <= 100)
            {
                m_diffState = 2;
            }
            else if (currentScore > 101 && currentScore <= 500)
            {
                m_diffState = 3;
            }
            else if (currentScore > 501)
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
            currentScore += CurrentsPointsByKill();
            GameManager.Instance.m_maxPxDuck = CurrentsPointsByKill();
            UpdateScore();
        }

        public int CurrentsPointsByKill()
        {
            return _duckPoints + bonusDuckPoints;
        }

        public void KillVampiDuck()
        {
            if (currentScore > 1) currentScore -= DrainPointsByKill();
            else if (currentScore == 1) currentScore = 0;
            else if (currentScore <= 0) currentScore = 0;
            
            UpdateScore();
        }

        public int DrainPointsByKill()
        {
            return Mathf.RoundToInt(currentScore * 50 / 100);
        }

        void UpdateScore()
        {
            _ducksKilledText.text = currentScore.ToString() + " p";
            GameManager.Instance.m_newScore = currentScore;
        }

        void ApplyBonusPoints(int id)
        {
            if (id == 2)
            {
                bonusDuckPoints += 2;
                _totalBonusPoints.text = CurrentsPointsByKill().ToString();
                GameManager.Instance.m_maxPxDuck = CurrentsPointsByKill();
            }
        }

        private void OnDestroy()
        {
            BalloonEvent.SetBonus -= ApplyBonusPoints;
        }
    }
}

