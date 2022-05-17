//Exercise 2: PoolRoom
//Manu Moral

using UnityEngine;

namespace UnityLessons
{

    public class TipDetection : MonoBehaviour
    {
        [SerializeField] DartMov dartMov;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Dartboard"))
            {
                dartMov.m_isMoving = false;
                dartMov.m_isNailed = true;
            }
        }
    }
}


