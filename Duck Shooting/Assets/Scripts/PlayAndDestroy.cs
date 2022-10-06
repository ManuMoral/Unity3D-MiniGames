//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class PlayAndDestroy : MonoBehaviour
    {
        ParticleSystem smashParticles;

        private void Awake()
        {
            smashParticles = GetComponent<ParticleSystem>();
        }

        void Start()
        {
            smashParticles.Play();
            Destroy(gameObject, .2f);
        }

    }
}


