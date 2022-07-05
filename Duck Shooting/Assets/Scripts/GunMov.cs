//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class GunMov : MonoBehaviour
    {
        [SerializeField] float _gunSpeed, _maxDistance, _bulletSpeed;
        [SerializeField] Bullet _bullet;
        [SerializeField] Rigidbody _waterBullet;
        [SerializeField] Transform _gunPivot, _bulletTarget, _gunPos;
        private float mouseX;
        private float mouseY;
        private readonly float sensitivity = 1;
        Vector3 bulletDir;
        AudioSource _shootSound;
        bool isShooting;

        private void Awake()
        {
            _shootSound = GetComponent<AudioSource>();
        }

        void Update()
        {
            ViewRotations();
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0) && !GameManager.Instance.m_playPause && !isShooting)
            {
                isShooting = true;
                GetBulletDir();
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(_waterBullet, bulletDir, _gunPivot.rotation) as Rigidbody;
                projectileInstance.AddForce(_gunPivot.forward * _bulletSpeed, ForceMode.Impulse);
                _shootSound.Play();
                Invoke(nameof(Recharge), 1f);
            }
        }

        void GetBulletDir()
        {
            bulletDir = Vector3.MoveTowards(new Vector3(_gunPos.position.x, _gunPos.position.y, _gunPos.position.z),
                _bulletTarget.position, _maxDistance);
        }

        void Recharge()
        {
            isShooting = !isShooting;
        }

        void ViewRotations()
        {
            if (!GameManager.Instance.m_playPause)
            {
                if (Input.mousePosition.x < 37) // Left limit
                {
                    mouseX += Input.GetAxis("Mouse X") * sensitivity;
                }
                else
            if (Input.mousePosition.x > -37) // Right limit
                {
                    mouseX += Input.GetAxis("Mouse X") * sensitivity;
                }
                else // Between limits
                {
                    if (Input.mousePosition.x > 37) mouseX = 37;
                    if (Input.mousePosition.x < -37) mouseX = -37;
                }

                if (Input.mousePosition.y < -1) // Left limit
                {
                    mouseY += Input.GetAxis("Mouse Y") * sensitivity;
                }
                else
                if (Input.mousePosition.y > -25) // Right limit
                {
                    mouseY += Input.GetAxis("Mouse Y") * sensitivity;
                }
                else // Between limits
                {
                    if (Input.mousePosition.y > -1) mouseY = -1;
                    if (Input.mousePosition.y < -25) mouseY = -25;
                }

                mouseY += Input.GetAxis("Mouse Y") * sensitivity;

                _gunPivot.transform.localEulerAngles = new Vector3(Mathf.Clamp(-mouseY, -25, -1), Mathf.Clamp(mouseX, -37, 37), 0);
            }

        }
    }
}

