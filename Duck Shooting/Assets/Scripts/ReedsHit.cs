//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class ReedsHit : MonoBehaviour
    {
        Animator _reedAnim;
        AudioSource _reedHitSound;

        private void Start()
        {
            _reedAnim = GetComponent<Animator>();
            _reedHitSound = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                _reedAnim.SetTrigger("Hit");
                if(!GameManager.Instance.m_isSoundOff) _reedHitSound.Play();
            }
        }
    }
}


