//Exercise 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class CloudMov : MonoBehaviour
    {
        [SerializeField] Vector3 _startPos;
        [SerializeField] float _speed, _reSpawnPoint;
        
        bool _isMoving;

        void Start()
        {
            _isMoving = true;
        }

        void Update()
        {
            if (transform.position.x >= _reSpawnPoint)
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
                transform.Translate(_speed * Time.deltaTime * Vector3.right);
            }
        }
    }
}

