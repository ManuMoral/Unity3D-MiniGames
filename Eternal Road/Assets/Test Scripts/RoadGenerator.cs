//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity3DMiniGames.RoadParentDetector;

namespace Unity3DMiniGames
{
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] GameObject[] _roadUnits; //Reemplazar por accesos a S.O.'s que contengan las Piezas
        [SerializeField] Transform[] _roadParents;
        int rngRoadUnit, roadOrder;

        void Start()
        {
            RoadEvent.NewRoadUnit += CreateNewRoadUnit;
            roadOrder = 0;
        }

        void CreateNewRoadUnit(int parentId) //ParentId -> Position of the Road Unit
        {
            if (roadOrder < 2)
            {
                GameObject myNewChild = Instantiate(_roadUnits[0], _roadParents[parentId].position, _roadParents[parentId].rotation);
                myNewChild.transform.SetParent(_roadParents[parentId]);
                myNewChild.transform.localScale = Vector3.one;
                roadOrder++;
            }
            else
            {
                rngRoadUnit = Random.Range(0, _roadUnits.Length);
                GameObject myNewChild = Instantiate(_roadUnits[rngRoadUnit], _roadParents[parentId].position, _roadParents[parentId].rotation);
                myNewChild.transform.SetParent(_roadParents[parentId]);
                myNewChild.transform.localScale = Vector3.one;
            }
        }

        private void OnDestroy()
        {
            RoadEvent.NewRoadUnit -= CreateNewRoadUnit;
        }
    }
}

