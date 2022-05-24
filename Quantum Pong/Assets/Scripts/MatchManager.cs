//Exercise 4: Quantum Pong
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] Ball _ballMov;

        void Start()
        {
            _ballMov.AddStartingForce();
        }

    }
}

