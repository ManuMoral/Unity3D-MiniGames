//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using System;

namespace Unity3DMiniGames
{
    public static class BalloonEvent
    {
        public static Action<int> SetBonus;
    }

    public class BonusBalloon : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _balloonColors, _balloonIcons;
        [SerializeField] float _speed, _amplitude, _frequency;
        [SerializeField] GameObject[] _particles;
        float xPos, counter, xSin;
        int bonusId;
        bool setedBonus;
        AudioSource _balloonSound;

        private void Start()
        {
            _balloonSound = GetComponent<AudioSource>();
            setedBonus = false;
            xPos = transform.position.x;
            bonusId = UnityEngine.Random.Range(0, _balloonColors.Length -1); //All - Purple
            if (GameManager.Instance.m_speedShootBonusOn && bonusId == 0) bonusId = OtherBonusId(); 
            SetBalloonProperties(bonusId);
        }

        void Update()
        {
            SinusoidalHMov();

            transform.Translate(_speed * Time.deltaTime * Vector3.up);
        }

        private int OtherBonusId()
        {
            return UnityEngine.Random.Range(1, _balloonColors.Length);
        }

        private void SinusoidalHMov()
        {
            counter += _frequency / 100;
            xSin = Mathf.Sin(counter);
            transform.position = new Vector3(xPos + (xSin * _amplitude), transform.position.y, transform.position.z);
            if (counter > 6.28f) counter = 0;
        }

        private void SetBalloonProperties(int id)
        {
            if (id == 0) //Red
            {
                _balloonColors[0].SetActive(true);
                //_balloonIcons[0].SetActive(true);
            }
            else if (id == 1) //Green
            {
                _balloonColors[1].SetActive(true);
                //_balloonIcons[1].SetActive(true);
            }
            else if (id == 2) //Yellow
            {
                _balloonColors[2].SetActive(true);
                //_balloonIcons[2].SetActive(true);
            }
            else if (id == 3) //Purple
            {
                _balloonColors[3].SetActive(true);
                //_balloonIcons[3].SetActive(true);
            }
        }

        private void CastParticlesColor(int id)
        {
            if (id == 0) //Red
            {
                Instantiate(_particles[0], transform.position, Quaternion.identity);
            }
            else if (id == 1) //Green
            {
                Instantiate(_particles[1], transform.position, Quaternion.identity);
            }
            else if (id == 2) //Yellow
            {
                Instantiate(_particles[2], transform.position, Quaternion.identity);
            }
            else if (id == 3) //Purple
            {
                Instantiate(_particles[3], transform.position, Quaternion.identity);
            }
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.collider.CompareTag("Bullet"))
            {
                if (!GameManager.Instance.m_isSoundOff) _balloonSound.Play();
                if (!setedBonus && !GameManager.Instance.m_isGameOver)
                {
                    BalloonEvent.SetBonus(bonusId);
                    CastParticlesColor(bonusId);

                    setedBonus = true;
                }
                _balloonColors[bonusId].transform.localScale = new Vector3(2, 2, 2);
                Destroy(gameObject, .1f);
            }

            if (col.collider.CompareTag("Floor"))
            {
                Destroy(gameObject);
            }
        }
    }
}
