//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class PowerUpPhysics : MonoBehaviour
    {
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                transform.SetParent(col.transform);
            }
        }
    }
}


