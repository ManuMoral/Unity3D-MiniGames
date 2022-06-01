//Exercise 2: PoolRoom
//Manu Moral

using UnityEngine;

namespace UnityLessons
{
    public class DropTheBall : MonoBehaviour
    {
        [SerializeField, Range(0, -90)] float _dropRotationAngle;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.rotation = Quaternion.Euler(0, 0, _dropRotationAngle);
            }
        }

    }
}

