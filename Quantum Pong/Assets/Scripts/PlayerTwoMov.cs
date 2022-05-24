//Exercise 4: Quantum Pong
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class PlayerTwoMov : PlayersMov
    {
        [SerializeField] float _pTwoSpeed, _pTwoYBound;
        private void Update()
        {
            MovController("Vertical2", transform.position, _pTwoSpeed, _pTwoYBound);
        }
    }
}

