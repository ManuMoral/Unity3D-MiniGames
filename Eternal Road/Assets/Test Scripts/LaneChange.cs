//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class LaneChange : MonoBehaviour
    {
        [SerializeField] Vector3 _laneOne, _laneTwo;
        [SerializeField] float _changeSeconds;
        [SerializeField] AnimationCurve _smoothChange;
        [SerializeField] BallPhysics _bph;
        [SerializeField] HUDDisplay _hud;
        bool isChanging, onRightLane;

        public float ChangeLaneDuration { get => _changeSeconds; set { _changeSeconds = value; } }

        private void Start()
        {
            transform.position = _laneOne;
            onRightLane = true;
        }

        void Update()
        {
            ChangeOfLane();
        }

        private void ChangeOfLane()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isChanging && !_bph.IsOutOfControl)
            {
                if (onRightLane && _bph.IsGroundOnLeft && !_bph.IsWallOnLeft)
                {
                    if (!_bph.IsBalloon && _bph.IsGrounded && !_bph.IsSmallPlasti && !_bph.IsOutOfControl)
                    {
                        isChanging = true;
                        StartCoroutine(LerpPosition(_laneOne, _laneTwo, _changeSeconds));
                        onRightLane = !onRightLane;
                        _hud.PushChangeLaneBTN(true);
                    }
                }
                else if (!onRightLane && _bph.IsGroundOnRight && !_bph.IsWallOnRight)
                {
                    if (!_bph.IsBalloon && _bph.IsGrounded && !_bph.IsSmallPlasti && !_bph.IsOutOfControl)
                    {
                        isChanging = true;
                        StartCoroutine(LerpPosition(_laneOne, _laneTwo, _changeSeconds));
                        onRightLane = !onRightLane;
                        _hud.PushChangeLaneBTN(true);
                    }
                }
                else if (!onRightLane && !_bph.IsGroundOnRight && !_bph.IsGroundOnLeft && !_bph.IsWallOnRight)
                {
                    if (_bph.IsBalloon && !_bph.IsGrounded && !_bph.IsOutOfControl)
                    {
                        isChanging = true;
                        StartCoroutine(LerpPosition(_laneOne, _laneTwo, _changeSeconds));
                        onRightLane = !onRightLane;
                        _hud.PushChangeLaneBTN(true);
                    }
                }
                else if (onRightLane && !_bph.IsGroundOnRight && !_bph.IsGroundOnLeft && !_bph.IsWallOnLeft)
                {
                    if (_bph.IsBalloon && !_bph.IsGrounded && !_bph.IsOutOfControl)
                    {
                        isChanging = true;
                        StartCoroutine(LerpPosition(_laneOne, _laneTwo, _changeSeconds));
                        onRightLane = !onRightLane;
                        _hud.PushChangeLaneBTN(true);
                    }
                }
            }
        }

        void SwitchTarget()
        {
            _laneTwo = _laneOne;
            _laneOne = transform.position;
            isChanging = false;
        }

        IEnumerator LerpPosition(Vector3 startPos, Vector3 targetPos, float lerpDuration)
        {
            float timeElapsed = 0f;

            while (timeElapsed < lerpDuration)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, _smoothChange.Evaluate(timeElapsed / lerpDuration));
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            _hud.PushChangeLaneBTN(false);
            transform.position = targetPos;
            SwitchTarget();
        }
    }
}


