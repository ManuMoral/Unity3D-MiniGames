//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class PlayersMov : MonoBehaviour
    {
        protected Rigidbody _rb;
        public bool m_isAI;
        [HideInInspector] public float m_currentSpeed, m_currentYBound;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void MovController(string inputAxis, Vector3 pPosition, float speed, float yBound)
        {
            float yMov = Input.GetAxisRaw(inputAxis);
            pPosition.y = Mathf.Clamp(pPosition.y + yMov * speed * Time.deltaTime, -yBound, yBound);
            transform.position = pPosition;
        }

        public void RestartPosition(Vector3 startPos)
        {
            _rb.position = startPos;
            _rb.velocity = Vector3.zero;
            _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        }
    }
}

