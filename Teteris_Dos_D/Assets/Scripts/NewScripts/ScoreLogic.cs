//Teteris MiniGame
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace UnityMiniGames
{
    public class ScoreLogic : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _scoreText;
        
        public void UpdateScores(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}


