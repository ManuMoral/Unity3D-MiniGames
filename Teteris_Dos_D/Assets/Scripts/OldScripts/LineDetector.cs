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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("BasicPiece"))
            {
                if (col.gameObject.GetComponent<PieceMov>().isNearFloor)
                {
                    transform.SetParent(col.transform, true);
                    Debug.Log("Cambio de Padre");
                }
            }
        }

        //REVISAR:
        private void OnTriggerStay2D(Collider2D col)
        {
        //    for (int i = 0; i < _detectors.Length; i++)
        //    {
        //        if (col.CompareTag("BasicPiece") && !lineCompleted)
        //        {
        //            transform.SetParent(_detectors[i].transform, true);
        //            celsCount++;
        //            if (celsCount == 10) lineCompleted = true;

        //            Debug.Log(celsCount);
        //        }
                    

        //        if (lineCompleted)
        //        {
        //            //Destroy(_detectors[i], 0.5f);
        //            //Mover esta Fila a la Posición de la 18 y bajar el resto, que estén por encima, una posición. Luego hacer que celsCount = 0; y lineCompleted a Falso
        //        }

        //    }
        }
    }

}

