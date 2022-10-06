//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class ReedInstancer : MonoBehaviour
    {
        [SerializeField] GameObject[] _reedsPF;
        [SerializeField] Transform[] _spawnPoints;
        int rngReed, rngSP, doubleSpawn, rngReed2, rngSP2;


        private void Start()
        {
            doubleSpawn = Random.Range(0, 4);
            
            if(doubleSpawn == 0)
            {
                rngReed = Random.Range(0, _reedsPF.Length);
                rngSP = Random.Range(0, _spawnPoints.Length);
                Instantiate(_reedsPF[rngReed], _spawnPoints[rngSP].position, Quaternion.identity);
            }
            else
            {
                rngReed = Random.Range(0, _reedsPF.Length);
                rngSP = Random.Range(0, _spawnPoints.Length);
                Instantiate(_reedsPF[rngReed], _spawnPoints[rngSP].position, Quaternion.identity);

                rngReed2 = Random.Range(0, _reedsPF.Length);
                rngSP2 = Random.Range(0, _spawnPoints.Length);

                if (rngReed2 == rngReed) rngReed2++;
                if (rngReed2 >= _reedsPF.Length) rngReed2--;

                if (rngSP2 == rngSP) rngSP2++;
                if (rngSP2 >= _spawnPoints.Length) rngSP2--;

                Instantiate(_reedsPF[rngReed2], _spawnPoints[rngSP2].position, Quaternion.identity);
            }
            
        }
    }
}


