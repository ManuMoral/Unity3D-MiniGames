//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class ChangeBallColor : MonoBehaviour
    {
        MeshRenderer _meshRdr;

        private void Awake()
        {
            _meshRdr = GetComponent<MeshRenderer>();
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("PaddleTwo"))
            {
                _meshRdr.material.color = new Color(1, 0, 0.13f, 1);
            }
            else if (col.gameObject.CompareTag("PaddleThree"))
            {
                _meshRdr.material.color = new Color(.75f, 0.6f, 0.1f, 1);
            }
            else if (col.gameObject.CompareTag("PaddleFour"))
            {
                _meshRdr.material.color = new Color(.1f, 0.75f, 0.2f, 1);
            }
        }
    }
}

