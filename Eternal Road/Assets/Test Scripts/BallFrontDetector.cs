//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class BallFrontDetector : MonoBehaviour
    {
        [SerializeField] BallPhysics _bph;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Floor"))
            {
                if (_bph.IsGum) _bph.GumOutOfControl(); //Lost Control for Gum
                if (_bph.IsStone) _bph.StoneCrash(); //Lost Control by Lock Position
                if (_bph.IsPlasti) _bph.CrashOnWall(); //Lost Control by Lock Position
                if (_bph.IsBalloon) _bph.CrashOnWall(); //Lost Control by Lock Position
            }

            if (other.CompareTag("Obstacle"))
            {
                if (_bph.IsGum) _bph.GumOutOfControl(); //Lost Control for Gum
                if (_bph.IsPlasti) _bph.CrashOnWall(); //Lost Control by Lock Position
                if (_bph.IsBalloon) _bph.CrashOnWall(); //Lost Control by Lock Position

                //Stone Ball Lost 1 Durability, but Destroy this Obstacle:
                if (_bph.IsStone)
                {
                    if (_bph.IsRush) Destroy(other.gameObject,.1f);
                    else
                    {
                        _bph.LostDurability(1);
                        Destroy(other.gameObject, .1f);
                    }
                }
                    
            }

            if (other.CompareTag("Hard_Obstacle"))
            {
                if (_bph.IsGum) _bph.GumOutOfControl(); //Lost Control for Gum
                if (_bph.IsPlasti) _bph.CrashOnWall(); //Lost Control by Lock Position
                if (_bph.IsBalloon) _bph.CrashOnWall(); //Lost Control by Lock Position

                //Stone Ball Lost 1 Durability, but Destroy this Obstacle:
                if (_bph.IsStone)
                {
                    if (_bph.IsRush)
                    {
                        _bph.LostDurability(1);
                        Destroy(other.gameObject, .1f);
                    }
                    else _bph.StoneCrash();
                }
            }
        }
    }
}


