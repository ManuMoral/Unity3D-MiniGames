//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class DuckMov : MonoBehaviour
    {
        [SerializeField] Vector3 _startPos, _reStartPos;
        [SerializeField] float _reSpawnPoint, _spawnOffset;
        public bool _isDuck, _isVampiDuck, _isDracuDuck, _isSuperDuck;
        [SerializeField] ScoreCalculator _scoreCal;
        [SerializeField] TimerCD _timerCD;
        [SerializeField] CameraShake _camShake;
        [SerializeField] MeshRenderer _duckMesh, _redMesh, _deathMesh;
        [SerializeField] GameObject _ballonPrefab, _pointsCanvas, _bonusCanvas, _smashParticlesPrefab;
        [SerializeField] Transform _dracuStartPoint, _dracuEndPoint, _particlesSP, _skyPlatform;
        [SerializeField] private LayerMask _Layer;
        [SerializeField] int _timeDracuDrain;
        
        public float _speed;
        float shakeDur, shakeMag;
        int diffPercentSubsPoints;

        Animator _sDAnim;
        Rigidbody _duckRb;
        AudioSource _duckSound;
        bool _isMoving, _onDiff1, _onDiff2, _onDiff3, _onDiff4, _spawnedBallon, _isShocked, _isDracuNear;

        private void Awake()
        {
            _duckRb = GetComponent<Rigidbody>();
            _duckSound = GetComponent<AudioSource>();
            if (_isSuperDuck) _sDAnim = GetComponent<Animator>();
        }

        void Start()
        {
            _isMoving = true;
            _onDiff1 = false;
            _onDiff2 = false;
            _onDiff3 = false;
            _onDiff4 = false;

            if (!_isDracuDuck)
            {
                _duckMesh.enabled = true;
                _redMesh.enabled = false;
            }
            else
            {
                _duckMesh.enabled = false;
                _redMesh.enabled = false;
                _Layer = (1 << 2);
            }

            BalloonEvent.SetBonus += DestroyAllBlackDucks;
        }

        void Update()
        {
            if (!GameManager.Instance.m_playPause) DuckMovement();

            //Increase the speed of the ducks (Difficulty Status):
            DuckSpeedSeter();
        }

        private void DuckSpeedSeter()
        {
            if (_isDuck || _isSuperDuck)
            {
                if (_scoreCal.m_diffState == 1 && !_onDiff1)
                {
                    _speed += .5f;
                    //diffPercentSubsPoints = 50;
                    _onDiff1 = true;
                    _onDiff2 = false;
                    _onDiff3 = false;
                    _onDiff4 = false;
                }
                else if (_scoreCal.m_diffState == 2 && !_onDiff2)
                {
                    _speed += 1.5f;
                    //diffPercentSubsPoints += 10;
                    _onDiff2 = true;
                    _onDiff1 = false;
                    _onDiff3 = false;
                    _onDiff4 = false;
                }
                else if (_scoreCal.m_diffState == 3 && !_onDiff3)
                {
                    _speed += 2.5f;
                    //diffPercentSubsPoints += 10;
                    _onDiff3 = true;
                    _onDiff1 = false;
                    _onDiff2 = false;
                    _onDiff4 = false;
                }
                else if (_scoreCal.m_diffState == 4 && !_onDiff4)
                {
                    _speed += 3.5f;
                    //diffPercentSubsPoints += 10;
                    _onDiff4 = true;
                    _onDiff1 = false;
                    _onDiff2 = false;
                    _onDiff3 = false;
                }
            }
        }

        private void DuckMovement()
        {
            if (!_isDracuDuck)
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
            }
            else
            {
                if (transform.position.y < _dracuEndPoint.position.y && transform.position.z < _dracuEndPoint.position.z)
                {
                    _isMoving = false;
                }

                if (!_isMoving)
                {
                    transform.position = _dracuStartPoint.position;
                    _duckMesh.enabled = false;
                    _isMoving = true;
                }
                else
                {
                    if (!_isShocked) transform.Translate(_speed * Time.deltaTime * new Vector3(1, -1, 0));
                }
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isDracuDuck && other.CompareTag("HorizonDetector"))
            {
                _duckMesh.enabled = true;
                _Layer = (1 << 11);
            }

            if (_isDracuDuck && other.CompareTag("Player"))
            {
                _timerCD.SubstractTime();
                StartCoroutine(_camShake.Shake(shakeDur, shakeMag));
            }
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.collider.CompareTag("Bullet"))
            {
                //Rubber Duck:
                if (_isDuck && !_isShocked) 
                {
                    ShockTheDuck();
                    _scoreCal.KillDuck();
                    GameManager.Instance.m_totalRD++;
                    GameObject duckCanvas;
                    duckCanvas = Instantiate(_pointsCanvas, transform.position + new Vector3(0, 6f, 0), Quaternion.identity);
                    duckCanvas.GetComponent<DuckPointsCanvas>().AddPoints(_scoreCal.CurrentsPointsByKill());
                    _isShocked = true;
                    Instantiate(_smashParticlesPrefab, _particlesSP.position + new Vector3(-.5f, 0.5f, -.5f), Quaternion.identity);
                }

                //The Baby Vampi Ducks substract points if we hit them
                if (_isVampiDuck && !_isShocked)
                {
                    ShockTheDuck();
                    GameManager.Instance.m_totalVD++;
                    if (_scoreCal.DrainPointsByKill() > 0)
                    {
                        GameObject duckCanvas;
                        duckCanvas = Instantiate(_pointsCanvas, transform.position + new Vector3(0, 6f, 0), Quaternion.identity);
                        duckCanvas.GetComponent<DuckPointsCanvas>().SubsPoints(_scoreCal.DrainPointsByKill());
                    }
                    else if (GameManager.Instance.m_newScore == 1)
                    {
                        GameObject duckCanvas;
                        duckCanvas = Instantiate(_pointsCanvas, transform.position + new Vector3(0, 6f, 0), Quaternion.identity);
                        duckCanvas.GetComponent<DuckPointsCanvas>().SubsPoints(1);
                    }
                    _scoreCal.KillVampiDuck();
                    _isShocked = true;
                    Instantiate(_smashParticlesPrefab, _particlesSP.position + new Vector3(-.5f, 0.5f, -.5f), Quaternion.identity);
                }

                //The Dracu Ducks substract time if it hits us
                if (_isDracuDuck && !_isShocked)
                {
                    ShockTheDuck();
                    GameManager.Instance.m_totalDD++;
                    _duckRb.constraints = RigidbodyConstraints.FreezeAll;
                    _duckRb.useGravity = false;
                    _isShocked = true;
                    Instantiate(_smashParticlesPrefab, _particlesSP.position + new Vector3(-1f, -1f, -1f), Quaternion.identity);
                }
                //Super Duck:
                if (_isSuperDuck)
                {
                    float rngY = Random.Range(9f, 18f);
                    _skyPlatform.position = new Vector3(_skyPlatform.position.x, rngY, _skyPlatform.position.z);
                    ShockTheDuck();
                    GameManager.Instance.m_totalSD++;
                    if (!_spawnedBallon)
                    {
                        Instantiate(_ballonPrefab, transform.position + Vector3.up * _spawnOffset, Quaternion.identity);
                        _spawnedBallon = true;
                    }
                    Instantiate(_bonusCanvas, transform.position + new Vector3(0, 6f, 0), Quaternion.identity);
                    Instantiate(_smashParticlesPrefab, _particlesSP.position + new Vector3(-.5f, 0.5f, -.5f), Quaternion.identity);
                }

                StartCoroutine(RestartDuck());
            }

            if (col.collider.CompareTag("Floor"))
            {
                if (_isDracuDuck)
                {
                    _duckRb.constraints = RigidbodyConstraints.FreezeAll;
                    _duckRb.useGravity = false;
                }
                StartCoroutine(RestartDuck());
            }
        }

        void ShockTheDuck()
        {
            shakeDur = Random.Range(.05f, .2f);
            shakeMag = Random.Range(.1f, .5f);
            StartCoroutine(_camShake.Shake(shakeDur, shakeMag));

            if (!_isDracuDuck) transform.Translate(_speed * Time.deltaTime * new Vector3(0, 3f, 0));
            if (!_isSuperDuck)
            {
                _redMesh.enabled = true;
                _duckMesh.enabled = false;
            }
            else
            {
                _sDAnim.SetTrigger("Death");
                _duckMesh.enabled = false;
            }
            
            if (_isDracuDuck) _Layer = (1 << 2);
            StartCoroutine(ReturnDefaultColor());
            if (!GameManager.Instance.m_isSoundOff) _duckSound.Play();
        }

        //Purple Bonus
        void DestroyAllBlackDucks(int id)
        {
            if (id == 3 && !GameManager.Instance.m_isGameOver)
            {
                if (_isDracuDuck || _isVampiDuck && !_isShocked)
                {
                    ShockTheDuck();
                    if (_isDracuDuck)
                    {
                        _duckRb.constraints = RigidbodyConstraints.FreezeAll;
                        _duckRb.useGravity = false;
                    }
                    _isShocked = true;
                    StartCoroutine(RestartDuck());
                }
            }
        }


        // We reposition the duck in the start spawn:
        IEnumerator RestartDuck()
        {
            yield return new WaitForSeconds(3f);
            _isMoving = false;
            if (!_isDracuDuck)
            {
                if (!_isSuperDuck)
                {
                    transform.SetPositionAndRotation(_reStartPos, Quaternion.Euler(new Vector3(0, -90, 0)));
                    _duckRb.constraints = RigidbodyConstraints.FreezeAll;
                    _duckRb.constraints = RigidbodyConstraints.None;
                }
                else
                {
                    transform.SetPositionAndRotation(new Vector3(_reStartPos.x,_skyPlatform.position.y + 2, _reStartPos.z), 
                        Quaternion.Euler(new Vector3(0, -90, 0)));
                    _duckRb.constraints = RigidbodyConstraints.FreezeAll;
                    _duckRb.constraints = RigidbodyConstraints.None;
                }
                
            }
            else
            {
                transform.SetPositionAndRotation(_dracuStartPoint.position, Quaternion.Euler(new Vector3(0, 90, 0)));
                _duckRb.constraints = RigidbodyConstraints.FreezeAll;
                StartCoroutine(UnFreezeConstrains());
            } 
            _deathMesh.enabled = false;
            if (!_isDracuDuck)_duckMesh.enabled = true;
            _isMoving = true;
            _spawnedBallon = false;
            _isShocked = false;
        }

        IEnumerator UnFreezeConstrains()
        {
            yield return new WaitForSeconds(1f);
            _duckRb.constraints = RigidbodyConstraints.FreezeRotation;
            _duckRb.useGravity = true;
        }

        IEnumerator ReturnDefaultColor()
        {
            yield return new WaitForSeconds(.5f);
            if (!_isSuperDuck)
            {
                _deathMesh.enabled = true;
                _redMesh.enabled = false;
            }
                
        }

        private void OnDestroy()
        {
            BalloonEvent.SetBonus -= DestroyAllBlackDucks;
        }
    }
}

