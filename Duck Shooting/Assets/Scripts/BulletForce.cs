//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class BulletForce : MonoBehaviour
    {

        void Start()
        {
            //TODO Particles?
            Destroy(gameObject, 3f);
        }

        private void OnCollisionEnter(Collision col)
        {
            //TODO Particles?
            Destroy(gameObject, .2f);
        }
    }
}
