//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class BallGroundDetector : MonoBehaviour
    {
        [SerializeField] BallPhysics _bph;
        [SerializeField] int _id;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Floor"))
            {
                if (_id == 0) _bph.IsGroundOnRight = true; //Right Floor
                if (_id == 1) _bph.IsGroundOnLeft = true; //Left Floor
                if (_id == 2) _bph.IsWallOnRight = true; //Right Wall
                if (_id == 3) _bph.IsWallOnLeft = true; //Left Wall
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Floor"))
            {
                if (_id == 0) _bph.IsGroundOnRight = false; //Right Floor
                if (_id == 1) _bph.IsGroundOnLeft = false; //Left Floor
                if (_id == 2) _bph.IsWallOnRight = false; //Right Wall
                if (_id == 3) _bph.IsWallOnLeft = false; //Left Wall
            }   
        }
    }
}


