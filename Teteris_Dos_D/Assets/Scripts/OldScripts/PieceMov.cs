//Teteris MiniGame
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMiniGames
{
    public class PieceMov : MonoBehaviour
    {
        [SerializeField] Collider2D[] _vColliders, _hColliders;
        [SerializeField] GameObject _blockCol;
        [SerializeField] int _deltaFrames;
        [SerializeField] Transform _pivot;
        [SerializeField] bool _isSquare, _isI, _isR,  _isZ, _isL, _isP, _isT, inHorizontal;
        bool isLocked, isRotateLock, newPieceInstanced;
        public bool isNearFloor;


        float leftLimit, rightLimit, leftAdjust, rightAdjust;
        int rotationAngles, rotStepT;

        private void Start()
        {
            SetProperties();
            if(!_isSquare) SwitchColliders();
        }

        void Update()
        {
            MoveDown();
            Rotate();
            HorizontalMov();
            UpdateLimits(); 
        }

        private void SwitchColliders()
        {
            if (inHorizontal)
            {
                EnableHColliders();
            }
            else
            {
                EnableVColliders();
            }
        }

        private void EnableHColliders()
        {
            for (int i = 0; i < _vColliders.Length; i++)
            {
                _vColliders[i].enabled = false;
            }
            for (int i = 0; i < _hColliders.Length; i++)
            {
                _hColliders[i].enabled = true;
            }
        }

        private void EnableVColliders()
        {
            for (int i = 0; i < _hColliders.Length; i++)
            {
                _hColliders[i].enabled = false;
            }
            for (int i = 0; i < _vColliders.Length; i++)
            {
                _vColliders[i].enabled = true;
            }
        }

        private void EnableAllColliders()
        {
            for (int i = 0; i < _hColliders.Length; i++)
            {
                _hColliders[i].enabled = true;
            }
            for (int i = 0; i < _vColliders.Length; i++)
            {
                _vColliders[i].enabled = true;
            }
        }

        private void SetProperties()
        {
            _blockCol.SetActive(false);

            if (_isSquare)
            {
                leftLimit = -4;
                rightLimit = 4;
            }
            else if (_isI)
            {
                rotationAngles = 90;
                inHorizontal = true;
                leftLimit = -3.5f;
                rightLimit = 2.5f;
            }
            else if (_isR)
            {
                rotationAngles = 90;
                inHorizontal = true;
                leftLimit = -3.5f;
                rightLimit = 3.5f;
            }
            else if (_isZ)
            {
                rotationAngles = 90;
                inHorizontal = true;
                leftLimit = -3.5f;
                rightLimit = 3.5f;
            }
            else if (_isL)
            {
                rotationAngles = 90;
                inHorizontal = true;
                leftLimit = -2.5f;
                rightLimit = 4.5f;
            }
            else if (_isP)
            {
                rotationAngles = 90;
                inHorizontal = true;
                leftLimit = -4.5f;
                rightLimit = 2.5f;
            }
            else if (_isT)
            {
                rotationAngles = 90;
                inHorizontal = true;
                leftLimit = -3.5f;
                rightLimit = 3.5f;
                rotStepT = 0;
            }

        }

        private void UpdateLimits()
        {
            if(_isI)
            {
                if (!inHorizontal)
                {
                    leftAdjust = -1f;
                    rightAdjust = 2f;
                }
                else
                {
                    leftAdjust = 0f;
                    rightAdjust = 0f;
                }
                
            }
            else if (_isZ)
            {
                if (!inHorizontal)
                {
                    leftAdjust = -1;
                    rightAdjust = 0;
                }
                else
                {
                    leftAdjust = 0f;
                    rightAdjust = 0f;
                }
            }
            else if (_isR) //R: -4.5 , 3.5
            {
                if (!inHorizontal)
                {
                    leftAdjust = -1;
                    rightAdjust = 0;
                }
                else
                {
                    leftAdjust = 0f;
                    rightAdjust = 0f;
                }
            }
            else if (_isP) // P:
            {
                if (rotStepT == 0) //H Up -4.5 , 2.5
                {
                    rotationAngles = 90;
                    leftAdjust = 0;
                    rightAdjust = 0;
                    inHorizontal = true;
                }
                else if (rotStepT == 1) //V Left -3.5 , 4.5
                {
                    rotationAngles = 90;
                    leftAdjust = 1;
                    rightAdjust = 2;
                    inHorizontal = false;
                }
                else if (rotStepT == 2) //H Down -2.5 , 4.5
                {
                    rotationAngles = 90;
                    leftAdjust = 2;
                    rightAdjust = -2;
                    inHorizontal = true;
                }
                else if (rotStepT == 3) //V Right -4.5 , 3.5
                {
                    rotationAngles = -270;
                    leftAdjust = 0;
                    rightAdjust = 1;
                    inHorizontal = false;
                }
            }
            else if (_isL) // L:
            {
                if (rotStepT == 0) //H Up -2.5 , 4.5
                {
                    rotationAngles = 90;
                    leftAdjust = 0;
                    rightAdjust = 0;
                    inHorizontal = true;
                }
                else if (rotStepT == 1) //V Left -3.5 , 4.5
                {
                    rotationAngles = 90;
                    leftAdjust = -1;
                    rightAdjust = 0;
                    inHorizontal = false;
                }
                else if (rotStepT == 2) //H Down -4.5 , 2.5
                {
                    rotationAngles = 90;
                    leftAdjust = -2;
                    rightAdjust = 2;
                    inHorizontal = true;
                }
                else if (rotStepT == 3) //V Right -4.5 , 3,5
                {
                    rotationAngles = -270;
                    leftAdjust = -2;
                    rightAdjust = -1;
                    inHorizontal = false;
                }
            }
            else if (_isT) // T90: -3.5 , 4.5 T-90: -4.5 , 3.5
            {

                if (rotStepT == 0) //H Up
                {
                    rotationAngles = 90;
                    leftAdjust = 0;
                    rightAdjust = 0;
                    inHorizontal = true;
                }
                else if (rotStepT == 1) //V Left
                {
                    rotationAngles = 90;
                    leftAdjust = 0;
                    rightAdjust = 1;
                    inHorizontal = false;
                }
                else if (rotStepT == 2) //H Down
                {
                    rotationAngles = 90;
                    leftAdjust = 0;
                    rightAdjust = 0;
                    inHorizontal = true;
                }
                else if (rotStepT == 3) //V Right
                {
                    rotationAngles = -270;
                    leftAdjust = -1;
                    rightAdjust = 0;
                    inHorizontal = false;
                }
            }
        }

        private void HorizontalMov()
        {
            if (Input.GetKeyDown(KeyCode.A) && !isNearFloor)
            {
                if(transform.position.x > leftLimit + leftAdjust)transform.Translate(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D) && !isNearFloor)
            {
                if (transform.position.x < rightLimit + rightAdjust) transform.Translate(1, 0, 0);
            }
        }

        private void Rotate()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isLocked && !_isSquare && !isRotateLock)
            {
                if (transform.position.x < rightLimit + rightAdjust && transform.position.x > leftLimit + leftAdjust)
                {
                    _pivot.transform.Rotate(new Vector3(0, 0, rotationAngles));
                     
                    if (_isI || _isR || _isZ)
                    {
                        rotationAngles *= -1;
                        inHorizontal = !inHorizontal;
                    }
                    else if (!_isT || !_isL || !_isP)
                    {
                        rotStepT++;
                        inHorizontal = !inHorizontal;
                        if (rotStepT > 3) rotStepT = 0;
                    }
                    SwitchColliders();
                }

            }
        }

        private void MoveDown()
        {
            if (!isNearFloor)
            {
                //Movimiento Vertical de la Pieza cada X Segundos:
                if (Time.frameCount % _deltaFrames == 0 && !isLocked)
                {
                    transform.Translate(0, -1, 0);
                }

                if (Input.GetKeyDown(KeyCode.S) && !isLocked)
                {
                    transform.Translate(0, -1, 0);
                }
            }
                
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Floor")) //Solo Horizontal
            {
                isLocked = true;
                //EnableAllColliders();
                StartCoroutine(WaitToLock());
            }
            else if (col.CompareTag("BasicPiece")) //Horizontal o Vertical
            {
                isLocked = true;
                //EnableAllColliders();
                StartCoroutine(WaitToLock());
            }

            if (col.CompareTag("Wall")) //Solo Vertical
            {
                isRotateLock = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Wall"))
            {
                isRotateLock = false;
            }
        }

        IEnumerator WaitToLock()
        {
            yield return new WaitForSeconds(.5f);
            isNearFloor = true;
            if (!newPieceInstanced)
            {
                GameManager.NewPiece();
                newPieceInstanced = true;
            }
        }
    }

}

