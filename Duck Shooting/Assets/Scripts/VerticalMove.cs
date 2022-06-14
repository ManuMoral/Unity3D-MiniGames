//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class VerticalMove : MonoBehaviour
    {
        [SerializeField] float _speed, _limitPoint;
        [SerializeField] Vector3 _startPos;

        bool _isMoving;

        private void Start()
        {
            _isMoving = true;
        }

        void Update()
        {
            if (transform.position.y < _limitPoint)
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
                transform.Translate(_speed * Time.deltaTime * Vector3.down);
            }
        }
    }
}

