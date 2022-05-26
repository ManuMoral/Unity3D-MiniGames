//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class BouncySurface : MonoBehaviour
    {
        [SerializeField] float _bounceStrength;
        
        private void OnCollisionEnter(Collision col)
        {
            Ball ballMov = col.gameObject.GetComponent<Ball>();
            if (ballMov != null)
            {
                Vector3 normal = col.GetContact(0).normal;
                ballMov.AddForce(-normal * _bounceStrength);
            }
        }
    }

}
