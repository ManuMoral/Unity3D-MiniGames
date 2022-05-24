//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class Ball : MonoBehaviour
    {
        Rigidbody _ballRb;
        public float m_ballSpeed;

        private void Awake()
        {
            _ballRb = GetComponent<Rigidbody>();
        }

        public void AddStartingForce()
        {
            float x = Random.value < .5f ? -1f : 1f;
            float y = Random.value < .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);

            Vector3 dir = new Vector3(x, y, 0f);
            _ballRb.AddForce(dir * m_ballSpeed);
        }

        public void AddForce(Vector3 force)
        {
            _ballRb.AddForce(force);
        }
    }
}

