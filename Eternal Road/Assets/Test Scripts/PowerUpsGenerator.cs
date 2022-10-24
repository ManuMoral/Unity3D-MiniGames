//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class PowerUpsGenerator : MonoBehaviour
    {
        [SerializeField] ContinousRotation _roadRot;
        [SerializeField] GameObject _gumPU, _balloonPU, _stonePU, _plastiPU;
        [SerializeField] Transform _spPos1, _spPos2;
        [SerializeField] float _time, _rate;
        int rngNum, rngPU;

        private void Start()
        {
            InvokeRepeating(nameof(GeneratePoweUp), _time, _rate);
        }

        void GeneratePoweUp()
        {
            if (!_roadRot.OnGameOver)
            {
                rngNum = Random.Range(0, 6);
                if (rngNum % 2 == 0)
                {
                    if (rngNum == 2)
                    {
                        rngPU = Random.Range(0, 4);
                        if (rngPU == 0) Instantiate(_gumPU, _spPos1.position, Quaternion.identity);
                        else if (rngPU == 1) Instantiate(_balloonPU, _spPos1.position, Quaternion.identity);
                        else if (rngPU == 2) Instantiate(_stonePU, _spPos1.position, Quaternion.identity);
                        else if (rngPU == 3) Instantiate(_plastiPU, _spPos1.position, Quaternion.identity);
                    }
                    else if (rngNum == 4)
                    {
                        rngPU = Random.Range(0, 4);
                        if (rngPU == 0) Instantiate(_gumPU, _spPos2.position, Quaternion.identity);
                        else if (rngPU == 1) Instantiate(_balloonPU, _spPos2.position, Quaternion.identity);
                        else if (rngPU == 2) Instantiate(_stonePU, _spPos2.position, Quaternion.identity);
                        else if (rngPU == 3) Instantiate(_plastiPU, _spPos2.position, Quaternion.identity);
                    }
                }
            }
                
        }
    }
}


