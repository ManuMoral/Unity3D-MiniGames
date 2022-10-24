//Final Round: Eternal Road
//Last Editor: Manu Moral

using System;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class RoadParentDetector : MonoBehaviour
    {
        bool newRoadIsInstanced, isFirstRoadUnit;
        int parentId;
        
        public static class RoadEvent
        {
            public static Action<int> NewRoadUnit;
        }

        private void Start()
        {
            isFirstRoadUnit = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("RoadUnitSP") && !newRoadIsInstanced)
            {
                if (!isFirstRoadUnit)
                {
                    parentId = other.GetComponent<RoadUnitParent>().RoadUnitParentID;

                    RoadEvent.NewRoadUnit(parentId);

                    newRoadIsInstanced = true;
                }
                else
                {
                    isFirstRoadUnit = false;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("RoadUnitSP"))
            {
                newRoadIsInstanced = false;
            }
        }
    }
}


