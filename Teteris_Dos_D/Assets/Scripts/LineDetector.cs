//Teteris MiniGame
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMiniGames
{
    public class LineDetector : MonoBehaviour
    {
        [SerializeField] GameObject[] _detectors;
        int celsCount;
        bool lineCompleted;

        void Start()
        {

        }

        void Update()
        {

        }

        //REVISAR:
        private void OnTriggerStay2D(Collider2D col)
        {
            for (int i = 0; i < _detectors.Length; i++)
            {
                if (_detectors[i].CompareTag("BasicPiece") && !lineCompleted)
                {
                    transform.SetParent(_detectors[i].transform);
                    celsCount++;
                    if (celsCount == 10) lineCompleted = true;
                }
                    

                if (lineCompleted)
                {
                    Destroy(_detectors[i], 0.5f);
                    //Mover esta Fila a la Posición de la 18 y bajar el resto, que esté por encima, una posición. Luego hacer que celsCount = 0; y lineCompleted a Falso
                }

            }
        }
    }

}

