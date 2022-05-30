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
        [HideInInspector] public float m_ballSpeed, m_velocityMultiplier;
        [SerializeField] MatchManager _matchM;
        float _x, _y;

        private void Awake()
        {
            _ballRb = GetComponent<Rigidbody>();
            _ballKnock = GetComponent<AudioSource>();
        }

        public void AddStartingForce()
        {
            if (_matchM.m_gameState == 1)
            {
                if (_matchM.m_p1ScoredGoal)
                {
                    _x = -1f;
                }
                else if (_matchM.m_p2ScoredGoal)
                {
                    _x = 1f;
                }
                else
                {
                    _x = Random.value < .5f ? -1f : 1f;
                }
                
                _y = Random.value < .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);

                Vector3 dir = new(_x, _y, 0f);
                _ballRb.AddForce(dir * m_ballSpeed);
            }
            
        }

        public void AddForce(Vector3 force)
        {
            _ballRb.AddForce(force);
        }

        public void LockMov()
        {
            _ballRb.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void UnlockMov()
        {
            _ballRb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        private void OnCollisionEnter(Collision col)
        {
            _ballKnock.Play();
            if (col.gameObject.CompareTag("PaddleOne"))
            {
                _ballRb.velocity *= m_velocityMultiplier;
                _matchM.m_lastPlayer = 1;
            }
            if (col.gameObject.CompareTag("PaddleTwo"))
            {
                _ballRb.velocity *= m_velocityMultiplier;
                _matchM.m_lastPlayer = 2;
            }
            if (col.gameObject.CompareTag("PaddleThree"))
            {
                _ballRb.velocity *= m_velocityMultiplier;
                _matchM.m_lastPlayer = 3;
            }
            if (col.gameObject.CompareTag("PaddleFour"))
            {
                _ballRb.velocity *= m_velocityMultiplier;
                _matchM.m_lastPlayer = 4;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //Goals 

            if (other.gameObject.CompareTag("GoalP1") && _matchM.m_gameState == 1)
            {
                _matchM.PlayerTwoScored();
                _matchM.RestoreBallStats();
                _matchM.RestorePlayersStats();
                StartCoroutine(WaitToLaunch());
            }
            if (other.gameObject.CompareTag("GoalP2") && _matchM.m_gameState == 1)
            {
                _matchM.PlayerOneScored();
                _matchM.RestoreBallStats();
                _matchM.RestorePlayersStats();
                StartCoroutine(WaitToLaunch());
            }

            //PowerUps:
            if (other.gameObject.CompareTag("BallSpeed") && _matchM.m_gameState == 1)
            {
                _matchM.m_pwrUpLaunch = false;
                //Sound
                _matchM.ApplyBallSpeedPU();
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("BallSize") && _matchM.m_gameState == 1)
            {
                _matchM.m_pwrUpLaunch = false;
                //Sound
                _matchM.ApplyBallSizePU();
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("PlayerSpeed") && _matchM.m_gameState == 1)
            {
                _matchM.m_pwrUpLaunch = false;
                //Sound
                _matchM.ApplyPlayerSpeedPU();
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("PlayerSize") && _matchM.m_gameState == 1)
            {
                _matchM.m_pwrUpLaunch = false;
                //Sound
                _matchM.ApplyPlayerSizePU();
                Destroy(other.gameObject);
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

