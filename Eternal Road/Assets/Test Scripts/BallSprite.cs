//Final Round: Eternal Road
//Last Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class BallSprite : MonoBehaviour
    {
        [SerializeField] Transform _ballPos;

        void Update()
        {
            transform.position = _ballPos.position;
        }
    }

}

