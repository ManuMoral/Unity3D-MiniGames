//Teteris MiniGame
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMiniGames
{
    public class AudioLogic : MonoBehaviour
    {
        AudioSource bgMusic;

        void Start()
        {
            bgMusic = GetComponent<AudioSource>();
            bgMusic.Play();
        }

    }
}


