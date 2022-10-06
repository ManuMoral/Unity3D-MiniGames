//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class BulletForce : MonoBehaviour
    {
        [SerializeField] ParticleSystem _waterDrops;

        void Start()
        {
            Destroy(gameObject, .5f);
        }

        private void OnCollisionEnter(Collision col)
        {
            _waterDrops.Play();
            Destroy(gameObject, .25f);
        }
    }
}
