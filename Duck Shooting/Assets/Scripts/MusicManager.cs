//Exercise 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity3DMiniGames
{
    public class MusicManager : MonoBehaviour
    {
        AudioSource _music;
        
        void Start()
        {
            _music = GetComponent<AudioSource>();
        }

        public void MuteMusic()
        {
            if(_music.mute) _music.mute = false;
            else _music.mute = true;
        }
    }
}

