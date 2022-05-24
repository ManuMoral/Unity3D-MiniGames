//Exercise 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class DuckMov : MonoBehaviour
    {
        [SerializeField] Vector3 _startPos, _reStartPos;
        [SerializeField] float _reSpawnPoint;
        public bool _isDuck, _isVampiDuck, _isSuperDuck;
        [SerializeField] ScoreCalculator _scoreCal;
        [SerializeField] MeshRenderer _duckMesh, _redMesh;

        public float _speed;

        Rigidbody _duckRb;
        AudioSource _duckSound;
        bool _isMoving, _onDiff1, _onDiff2, _onDiff3, _onDiff4;

        private void Awake()
        {
            _duckRb = GetComponent<Rigidbody>();
            _duckSound = GetComponent<AudioSource>();
        }

        void Start()
        {
            _isMoving = true;
            _onDiff1 = false;
            _onDiff2 = false;
            _onDiff3 = false;
            _onDiff4 = false;

            _duckMesh.enabled = true;
            _redMesh.enabled = false;
        }

        void Update()
        {

            if (transform.position.x < _reSpawnPoint)
            {
                _isMoving = false;
            }

            if (!_isMoving)
            {
                transform.position = _startPos;
                _isMoving = true;
            }
            else
            {
                transform.Translate(_speed * Time.deltaTime * Vector3.forward);
            }

            //Increase Speed in Ducks
            if (_isDuck || _isSuperDuck)
            {
                if (_scoreCal.m_diffState == 1 && !_onDiff1)
                {
                    _speed += .5f;
                    _onDiff1 = true;
                    _onDiff2 = false;
                    _onDiff3 = false;
                    _onDiff4 = false;
                }
                else if (_scoreCal.m_diffState == 2 && !_onDiff2)
                {
                    _speed += 1.5f;
                    _onDiff2 = true;
                    _onDiff1 = false;
                    _onDiff3 = false;
                    _onDiff4 = false;
                }
                else if (_scoreCal.m_diffState == 3 && !_onDiff3)
                {
                    _speed += 2.5f;
                    _onDiff3 = true;
                    _onDiff1 = false;
                    _onDiff2 = false;
                    _onDiff4 = false;
                }
                else if (_scoreCal.m_diffState == 4 && !_onDiff4)
                {
                    _speed += 3.5f;
                    _onDiff4 = true;
                    _onDiff1 = false;
                    _onDiff2 = false;
                    _onDiff3 = false;
                }
            }

        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.collider.CompareTag("Bullet"))
            {
                if (_isDuck)
                {
                    transform.Translate(_speed * Time.deltaTime * new Vector3(0, 3f, 0));
                    _redMesh.enabled = true;
                    _duckMesh.enabled = false;
                    StartCoroutine(ReturnDefaultColor());
                    _duckSound.Play();
                    _scoreCal.KillDuck();
                }

                if (_isVampiDuck)
                {
                    transform.Translate(_speed * Time.deltaTime * new Vector3(0, 3f, 0));
                    _redMesh.enabled = true;
                    _duckMesh.enabled = false;
                    StartCoroutine(ReturnDefaultColor());
                    _duckSound.Play();
                    _scoreCal.KillVampiDuck();
                }

                if (_isSuperDuck)
                {
                    transform.Translate(_speed * Time.deltaTime * new Vector3(0, 3f, 0));
                    _redMesh.enabled = true;
                    _duckMesh.enabled = false;
                    StartCoroutine(ReturnDefaultColor());
                    _duckSound.Play();
                    _scoreCal.KillSuperDuck();
                }

                StartCoroutine(RestartDuck());
            }

            if (col.collider.CompareTag("Floor"))
            {
                
                StartCoroutine(RestartDuck());
            }
        }

        // We reposition the duck in the start spawn:
        IEnumerator RestartDuck()
        {
            yield return new WaitForSeconds(3f);
            _isMoving = false;
            transform.SetPositionAndRotation(_reStartPos, Quaternion.Euler(new Vector3(0, -90, 0)));
            _duckRb.constraints = RigidbodyConstraints.FreezeAll;
            _duckRb.constraints = RigidbodyConstraints.None;
            _isMoving = true;
        }

        IEnumerator ReturnDefaultColor()
        {
            yield return new WaitForSeconds(.5f);
            _duckMesh.enabled = true;
            _redMesh.enabled = false;
        }
    }
}

