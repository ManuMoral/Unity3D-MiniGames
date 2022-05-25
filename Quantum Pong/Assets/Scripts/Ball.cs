//Exercise 4: Quantum Pong
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class Ball : MonoBehaviour
    {
        Rigidbody _ballRb;
        AudioSource _ballKnock;
        public float m_ballSpeed;
        [SerializeField] float _velocityMultiplier;
        [SerializeField] MatchManager _matchM;

        private void Awake()
        {
            _ballRb = GetComponent<Rigidbody>();
            _ballKnock = GetComponent<AudioSource>();
        }

        public void AddStartingForce()
        {
            if (_matchM.m_gameState == 1)
            {
                float x = Random.value < .5f ? -1f : 1f;
                float y = Random.value < .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);

                Vector3 dir = new(x, y, 0f);
                _ballRb.AddForce(dir * m_ballSpeed);
            }
            
        }

        public void AddForce(Vector3 force)
        {
            _ballRb.AddForce(force);
        }

        private void OnCollisionEnter(Collision col)
        {
            _ballKnock.Play();
            if (col.gameObject.CompareTag("Paddle"))
            {
                _ballRb.velocity *= _velocityMultiplier;
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("GoalP1") && _matchM.m_gameState == 1)
            {
                _matchM.PlayerTwoScored();
                StartCoroutine(WaitToLaunch());
            }
            if (other.gameObject.CompareTag("GoalP2") && _matchM.m_gameState == 1)
            {
                _matchM.PlayerOneScored();
                StartCoroutine(WaitToLaunch());
            }
        }

        IEnumerator WaitToLaunch()
        {
            _matchM.RestartPoint();
            _ballRb.constraints = RigidbodyConstraints.FreezeAll;
            yield return new WaitForSeconds(2f); //Wait 2" to Launch the Ball
            _ballRb.constraints = RigidbodyConstraints.FreezeRotation;
            AddStartingForce();
        }
    }
}

