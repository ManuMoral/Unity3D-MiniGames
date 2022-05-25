//Exercise 4: Quantum Pong
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] Ball _ballMov;
        [SerializeField] TMP_Text _p1ScoreText, _p2ScoreText;
        [SerializeField] PlayersMov _pOne, _pTwo;
        [SerializeField] GameObject _p1WinPanel, _p2WinPanel;

        int _p1Score, _p2Score;
        AudioSource _highGong;

        //GameState: 0 -> Pause / 1 -> OnPlay
        public int m_gameState;

        private void Awake()
        {
            _highGong = GetComponent<AudioSource>();
            m_gameState = 1;
        }

        void Start()
        {
            _ballMov.AddStartingForce();
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
                }
                if (_p2Score == 10)
                {
                    _p2WinPanel.SetActive(true);
                }
            }
        }

        public void PlayerOneScored()
        {
            _p1Score++;
            _p1ScoreText.text = _p1Score.ToString();
            _highGong.Play();
        }

        public void PlayerTwoScored()
        {
            _p2Score++;
            _p2ScoreText.text = _p2Score.ToString();
            _highGong.Play();
        }

        public void RestartPoint()
        {
            _pOne.gameObject.transform.position = new Vector3(-17, 0, - 1);
            _pTwo.gameObject.transform.position = new Vector3(17, 0, -1);
            _ballMov.gameObject.transform.position = new Vector3(0, 0, -.9f);
        }

    }
}

