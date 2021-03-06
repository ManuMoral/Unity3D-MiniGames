//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class Bullet : MonoBehaviour
    {
        Rigidbody _bulletRb;
        AudioSource _bulletSound;
        [SerializeField] float _speed, _yDir;
        [SerializeField] bool _isMoving, _isShooting;
        [SerializeField] Transform _gunPos;
        public float m_xDir;

        private void Awake()
        {
            _bulletRb = GetComponent<Rigidbody>();
            _bulletSound = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!GameManager.Instance.m_playPause) //Pause State
            {
                if (Input.GetKeyDown(KeyCode.Space) && !_isMoving)
                {
                    _isShooting = true;
                    _isMoving = true;
                    _bulletSound.Play();
                    StartCoroutine(TimeToReloadBullet());
                }
            }

            if (Input.GetKeyDown(KeyCode.R)) BulletReload();
        }

        private void FixedUpdate()
        {
            if (_isShooting)
            {
                AddStartingForce();
                _isShooting = false;
            }
        }

        void AddStartingForce()
        {
            _bulletRb.AddForce(_speed * new Vector3(m_xDir, _yDir, 1), ForceMode.Impulse);
        }

        IEnumerator TimeToReloadBullet()
        {
            yield return new WaitForSeconds(1f);
            BulletReload();
        }

        public void BulletReload()
        {
            _bulletRb.transform.position = _gunPos.position;
            _bulletRb.velocity = Vector3.zero;
            _isMoving = false;
        }

    }
}

