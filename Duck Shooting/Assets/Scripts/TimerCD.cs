//Exercise 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class TimerCD : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _timerText;
        [SerializeField] GameObject _timeOutDisplay;
        [SerializeField] int _totalTime;
        int _currentTime;
        float _timeStamp;

        public bool m_isGameOver;

        void Start()
        {
            _currentTime = _totalTime;
            _timerText.text = _currentTime.ToString();
            _timeOutDisplay.SetActive(false);
        }
      
        void Update()
        {
            //Timer Count Down
            if (Time.time - _timeStamp > 1 && _totalTime -1 > -1)
            {
                _totalTime--;
                _timeStamp = Time.time;
                _currentTime = _totalTime;
                _timerText.text = _currentTime.ToString();
            }

            if (_totalTime == 0)
            {
                StartCoroutine(WaitToLoadEndScene());
                m_isGameOver = true;
                _timeOutDisplay.SetActive(true);
                GameManager.Instance.m_playPause = true;
            }
        }

        IEnumerator WaitToLoadEndScene()
        {
            yield return new WaitForSeconds(3);
            GameManager.Instance.LoadEndGameScene();
        }
    }
}


