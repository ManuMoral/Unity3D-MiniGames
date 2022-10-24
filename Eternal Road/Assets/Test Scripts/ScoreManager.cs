//Final Round: Eternal Road
//Last Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class ScoreManager : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _scorePoints;
        int scorePoints;

        private void Start()
        {
            scorePoints = 0;
            UpdateScore();
        }

        public void AddPoints()
        {
            scorePoints++;
            UpdateScore();
        }

        public void ResetPoints()
        {

        }

        void UpdateScore()
        {
            _scorePoints.text = scorePoints.ToString() + " Points";
        }

    }
}


