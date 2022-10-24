//Final Round: Eternal Road
//Last Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    public class DestroyerPortal : MonoBehaviour
    {
        [SerializeField] ScoreManager _sm;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Floor"))
            {
                _sm.AddPoints();
                Destroy(other.gameObject, .1f);
            }
        }
    }
}


