//Final Round: Eternal Road
//Last Editor: Manu Moral
//Solo Test

using UnityEngine;

namespace Unity3DMiniGames
{
    [RequireComponent(typeof(Rigidbody))]

    public class BallJump : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField] float _jumpForce;
        [SerializeField] ContinousRotation _roadRot;
        bool isJump, isGrounded;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ReadInput();
        }

        private void FixedUpdate()
        {
            Jump();
        }

        void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) isJump = true;
        }

        void Jump()
        {
            if (isJump)
            {
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                isJump = false;
            }
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
            }
            else if (col.gameObject.CompareTag("FloorPortal"))
            {
                isGrounded = false;
                _roadRot.OnGameOver = true; //Game Over by Fall in Abyss
            }
        }

        private void OnCollisionStay(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                isGrounded = false;
            }
        }
    }
}


