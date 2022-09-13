//Teteris MiniGame
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMiniGames
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _pieces;
        [SerializeField] Transform[] _centerSp, _edgeSp;

        //Singleton structure:
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        private void Awake()
        {
            //Singleton structure:
            if (instance == null) instance = this;
            else Destroy(gameObject);
            DontDestroyOnLoad(this);

            //Seteamos FrameRate a 30FpS:
            Application.targetFrameRate = 30;
        }

        private void Start()
        {
            NewPiece();
        }

        public static void NewPiece()
        {
            int rngP = Random.Range(0, Instance._pieces.Length);
            int rngcSp = Random.Range(0, Instance._centerSp.Length);
            int rngeSp = Random.Range(0, Instance._edgeSp.Length);
            if (rngP != 0) Instantiate(Instance._pieces[rngP], Instance._centerSp[rngcSp].position, Quaternion.identity);
            else Instantiate(Instance._pieces[rngP], Instance._edgeSp[rngeSp].position, Quaternion.identity);

        }
    }
}


