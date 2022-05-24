//Exercise 4: Quantum Pong
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class PlayerOneMov : PlayersMov
    {
        [SerializeField] float _pOneSpeed, _pOneYBound;
        private void Update()
        {
            MovController("Vertical",transform.position,_pOneSpeed,_pOneYBound);
        }
    }
}

