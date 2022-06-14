//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class SDuckRotation : MonoBehaviour
    {
        [SerializeField] float _rotSpeed;
        void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, _rotSpeed * Time.deltaTime);
        }
    }
}

