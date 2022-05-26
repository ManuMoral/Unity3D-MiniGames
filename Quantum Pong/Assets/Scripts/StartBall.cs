//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class StartBall : MonoBehaviour
    {
        [SerializeField] float _launchDelay;
        Rigidbody _ballRb;
        AudioSource _ballKnock;
        public float m_ballSpeed;
        float _x, _y;       
        
        private void Awake()
        {
            _ballRb = GetComponent<Rigidbody>();
            _ballKnock = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Invoke(nameof(AddStartingForce), _launchDelay);
        }

        public void AddStartingForce()
        {
            _x = Random.value < .5f ? -1f : 1f;
            _y = Random.value < .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);

            Vector3 dir = new(_x, _y, 0f);
            _ballRb.AddForce(dir * m_ballSpeed);

        }

        private void OnCollisionEnter(Collision col)
        {
            _ballKnock.Play();
        }
    }
}

