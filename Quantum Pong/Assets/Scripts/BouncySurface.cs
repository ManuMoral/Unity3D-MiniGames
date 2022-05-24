//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class BouncySurface : MonoBehaviour
    {
        [SerializeField] float _bounceStrength, _decelerateStrength;
        
        private void OnCollisionEnter(Collision col)
        {
            Ball ballMov = col.gameObject.GetComponent<Ball>();
            if (ballMov != null)
            {
                Vector3 normal = col.GetContact(0).normal;
                if (ballMov.m_ballSpeed <= 100f) ballMov.AddForce(-normal * _bounceStrength);
                else if (ballMov.m_ballSpeed > 100f) ballMov.AddForce(-normal * _decelerateStrength);
            }
        }
    }

}
