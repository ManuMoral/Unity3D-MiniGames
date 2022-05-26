//Exercise 4: Quantum Pong
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class AIPlayerMov : PlayersMov
    {
        [SerializeField] Rigidbody _ballRb;
        [SerializeField] float _pTwoSpeed, _pTwoYBound;
        float _startSpeed;

        private void Start()
        {
            _startSpeed = _pTwoSpeed;
        }

        private void FixedUpdate()
        {
            if (_ballRb.velocity.x < 16f)
            {
                _pTwoSpeed = _startSpeed;
                _rb.isKinematic = false;
                _rb.constraints = RigidbodyConstraints.FreezeRotation;

                if (_ballRb.velocity.x > 0f)
                {
                    if (_ballRb.position.y > transform.position.y)
                    {
                        _rb.AddForce(Vector3.up * _pTwoSpeed, ForceMode.VelocityChange);
                    }
                    else if (_ballRb.position.y < transform.position.y)
                    {
                        _rb.AddForce(Vector3.down * _pTwoSpeed, ForceMode.VelocityChange);
                    }
                }
                else
                {
                    if (transform.position.y > 0f && transform.position.y < _pTwoYBound)
                    {
                        _rb.isKinematic = false;
                        _rb.velocity = Vector3.zero;
                        _rb.constraints = RigidbodyConstraints.FreezeRotation;
                        _rb.AddForce(Vector3.down * _pTwoSpeed, ForceMode.VelocityChange);
                    }
                    else if (transform.position.y < 0f && transform.position.y > -_pTwoYBound)
                    {
                        _rb.isKinematic = false;
                        _rb.velocity = Vector3.zero;
                        _rb.constraints = RigidbodyConstraints.FreezeRotation;
                        _rb.AddForce(Vector3.up * _pTwoSpeed, ForceMode.VelocityChange);
                    }
                    else
                    {
                        _pTwoSpeed = 0f;
                        _rb.velocity = Vector3.zero;
                        _rb.isKinematic = true;
                        if (transform.position.y != 0) _rb.constraints = RigidbodyConstraints.FreezeAll;
                    }
                }
            }
            else
            {
                _pTwoSpeed = 0f;
                _rb.velocity = Vector3.zero;
                _rb.isKinematic = true;
                _rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}

