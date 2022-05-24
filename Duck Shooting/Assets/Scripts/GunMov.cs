//Exercise 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class GunMov : MonoBehaviour
    {
        [SerializeField] float _gunSpeed, _YRot, _bRot;
        [SerializeField] Vector3 _horizontalMov;
        [SerializeField] Bullet _bullet;
        float _currentYRot;

        void Update()
        {

            if (!GameManager.Instance.m_playPause)
            {

                if (Input.GetKey(KeyCode.A))
                {
                    if (transform.position.x > -2)
                    {
                        _bullet.BulletReload();
                        transform.Translate(_gunSpeed * Time.deltaTime * Vector3.left);
                    }
                }

                if (Input.GetKey(KeyCode.D))
                {
                    if (transform.position.x < 2)
                    {
                        transform.Translate(_gunSpeed * Time.deltaTime * Vector3.right);
                    }
                }

                if (transform.position.x == 0)
                {
                    _bullet.m_xDir = 0;
                }
            }
        }

    }
}

