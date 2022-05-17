//Exercise 2: PoolRoom
//Manu Moral

using UnityEngine;

namespace UnityLessons
{
    public class DartMov : MonoBehaviour
    {
        [SerializeField] Vector3 _verticalMov = new Vector3(0, 0.5f,0);
        [SerializeField] Vector3 _horizontalMov = new Vector3(0.5f, 0, 0);
        [SerializeField] float _speed;

        public bool m_isMoving, m_isNailed;

        void Update()
        {
            if (!m_isMoving)
            {
                if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 2 && !m_isNailed)
                {
                    transform.position += _verticalMov;
                }

                if (Input.GetKeyDown(KeyCode.S) && transform.position.y > 0.09 && !m_isNailed)
                {
                    transform.position -= _verticalMov;
                }

                if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 5.9 && !m_isNailed)
                {
                    transform.position += _horizontalMov;
                }

                if (Input.GetKeyDown(KeyCode.A) && transform.position.x > 2.95 && !m_isNailed)
                {
                    transform.position -= _horizontalMov;
                }

                if (Input.GetKeyDown(KeyCode.Space) && !m_isNailed)
                {
                    m_isMoving = true;
                }

            }
            else
            {
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }
            
        }

    }
}


