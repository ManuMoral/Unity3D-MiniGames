//Exercise 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class DuckMov : MonoBehaviour
    {
        [SerializeField] Vector3 _startPos, _reStartPos;
        [SerializeField] float _speed;
        Rigidbody _duckRb;
        bool _isMoving;
        

        private void Awake()
        {
            _duckRb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            
            _isMoving = true;
        }

        void Update()
        {

            if (transform.position.x < -10.6f)
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
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }

            if (transform.rotation != Quaternion.Euler(new Vector3(0, -90, 0)))
            {
                StartCoroutine(RestartDuck());
            }
            
        }

        private void OnCollisionEnter(Collision col)
        {
            
            if (col.collider.CompareTag("Bullet"))
            {
                StartCoroutine(RestartDuck());
            }

            if (col.collider.CompareTag("Floor"))
            {
                Debug.Log("En el Suelo");
                StartCoroutine(RestartDuck());
            }
        }

        IEnumerator RestartDuck()
        {
            yield return new WaitForSeconds(1f);
            _isMoving = false;
            transform.SetPositionAndRotation(_reStartPos, Quaternion.Euler(new Vector3(0, -90, 0)));
            _duckRb.constraints = RigidbodyConstraints.FreezeAll;
            _duckRb.constraints = RigidbodyConstraints.None;
            _isMoving = true;
        }
    }
}

