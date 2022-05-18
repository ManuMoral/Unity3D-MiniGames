//Exercise 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class Bullet : MonoBehaviour
    {
        Rigidbody _bulletRb;
        [SerializeField] float _speed, _yDir;
        [SerializeField] bool _isMoving, _shoot;

        Vector3 _startPosBullet;
        int _puntuation;

        private void Awake()
        {
            _bulletRb = GetComponent<Rigidbody>();
            _startPosBullet = _bulletRb.transform.position;
        }

        private void Start()
        {
            _puntuation = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isMoving)
            {
                _shoot = true;
                _isMoving = true;
                StartCoroutine(ResetBullet());
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _bulletRb.transform.position = _startPosBullet;
                _bulletRb.velocity = Vector3.zero;
                _isMoving = false;
            }
        }

        private void FixedUpdate()
        {
            if (_shoot)
            {
                AddStartingForce();
                _shoot = false;
            }
        }

        void AddStartingForce()
        {
            _bulletRb.AddForce(_speed * new Vector3(0, _yDir, 1), ForceMode.Impulse);
        }

        IEnumerator ResetBullet()
        {
            yield return new WaitForSeconds(1f);
            _bulletRb.transform.position = _startPosBullet;
            _bulletRb.velocity = Vector3.zero;
            _isMoving = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _puntuation++;
            Debug.Log(_puntuation + " Puntos");
        }
    }
}

