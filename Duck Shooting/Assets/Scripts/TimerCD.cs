//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class TimerCD : MonoBehaviour
    {
        [SerializeField] SceneLoadManager _sceneLoadM;
        [SerializeField] TextMeshProUGUI _timerText;
        [SerializeField] GameObject _timeOutDisplay;
        [SerializeField] int _totalTime, _bonusTime, _percentToDrain;
        AudioSource _auSRC;
        [SerializeField] AudioClip _bell;
        public int m_timeLeft, m_totalTimeDrain;
        int _currentTime;
        float _timeStamp;
        bool bellHasRung;

        void Start()
        {
            _currentTime = _totalTime;
            _timerText.text = _currentTime.ToString();
            _timeOutDisplay.SetActive(false);
            _auSRC = GetComponent<AudioSource>();
            BalloonEvent.SetBonus += AddBonusTime;
        }
      
        void Update()
        {
            if (!GameManager.Instance.m_playPause) CountDownTimer();
        }

        private void CountDownTimer()
        {
            if (Time.time - _timeStamp > 1 && _totalTime - 1 > -1)
            {
                _totalTime--;
                _timeStamp = Time.time;
                _currentTime = _totalTime;
                m_timeLeft = _currentTime;
                _timerText.text = _currentTime.ToString() + " s";
                bellHasRung = false;
            }

            if (_totalTime == 0)
            {
                if (!bellHasRung && !GameManager.Instance.m_isSoundOff) _auSRC.PlayOneShot(_bell, .5f);
                StartCoroutine(TimeToLoadScene());
                GameManager.Instance.m_isGameOver = true;
                _timeOutDisplay.SetActive(true);
                GameManager.Instance.m_playPause = true;
            }
        }

        void AddBonusTime(int id)
        {
            if (id == 1)
            {
                _totalTime += _bonusTime;
                GameManager.Instance.m_maxTimeEarn += _bonusTime;
            }
        }

        public void SubstractTime()
        {
            m_totalTimeDrain = Mathf.RoundToInt(_currentTime * _percentToDrain / 100);
            _totalTime -= m_totalTimeDrain;  
        }

        IEnumerator TimeToLoadScene()
        {
            bellHasRung = true;
            yield return new WaitForSeconds(3f);

            StartCoroutine(_sceneLoadM.SceneLoad(3));
        }

        private void OnDestroy()
        {
            BalloonEvent.SetBonus -= AddBonusTime;
        }
    }
}


