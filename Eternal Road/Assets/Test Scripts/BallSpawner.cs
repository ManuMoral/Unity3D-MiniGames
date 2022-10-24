//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] GameObject _ball;
        [SerializeField] float _launchDelay;
        bool ballSpawned;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Floor") && !ballSpawned)
            {
                Invoke(nameof(LaunchBall), _launchDelay);
            }
        }

        void LaunchBall()
        {
            _ball.SetActive(true);

            ballSpawned = true;
        }
    }
}


