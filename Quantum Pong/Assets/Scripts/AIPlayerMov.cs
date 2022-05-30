//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class AIPlayerMov : PlayersMov
    {
        [SerializeField] Rigidbody _ballRb;
        float _startSpeed;

        private void Start()
        {
            _startSpeed = m_currentSpeed;
        }

        private void FixedUpdate()
        {
            if (_ballRb.position.x < 16f)
            {
                m_currentSpeed = _startSpeed;
                _rb.isKinematic = false;
                _rb.constraints = RigidbodyConstraints.FreezeRotation;

                if (_ballRb.velocity.x > 0f)
                {
                    if (_ballRb.position.y > transform.position.y)
                    {
                        _rb.AddForce(Vector3.up * m_currentSpeed, ForceMode.VelocityChange);
                    }
                    else if (_ballRb.position.y < transform.position.y)
                    {
                        _rb.AddForce(Vector3.down * m_currentSpeed, ForceMode.VelocityChange);
                    }
                }
                else
                {
                    if (transform.position.y > 0f && transform.position.y < m_currentYBound)
                    {
                        _rb.isKinematic = false;
                        _rb.velocity = Vector3.zero;
                        _rb.constraints = RigidbodyConstraints.FreezeRotation;
                        _rb.AddForce(Vector3.down * m_currentSpeed, ForceMode.VelocityChange);
                    }
                    else if (transform.position.y < 0f && transform.position.y > -m_currentYBound)
                    {
                        _rb.isKinematic = false;
                        _rb.velocity = Vector3.zero;
                        _rb.constraints = RigidbodyConstraints.FreezeRotation;
                        _rb.AddForce(Vector3.up * m_currentSpeed, ForceMode.VelocityChange);
                    }
                    else
                    {
                        m_currentSpeed = 0f;
                        _rb.velocity = Vector3.zero;
                        _rb.isKinematic = true;
                        if (transform.position.y != 0) _rb.constraints = RigidbodyConstraints.FreezeAll;
                    }
                }
            }
            else
            {
                m_currentSpeed = 0f;
                _rb.velocity = Vector3.zero;
                _rb.isKinematic = true;
                _rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}

