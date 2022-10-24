//Final Round: Eternal Road
//Last Editor: Manu Moral

using System.Collections;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class ContinousRotation : MonoBehaviour
    {
        [SerializeField] Transform _xRot;
        [SerializeField] float _rotSpeed, _transTime;
        [SerializeField] AnimationCurve smoothCant;
        [SerializeField] Vector3 _maxCant;
        bool onRoadCant, onGameOver;
        float startRotSpeed;
        Quaternion minCant;

        public bool OnRoadCant { get => onRoadCant; set { onRoadCant = value; } }
        public bool OnGameOver { get => onGameOver; set { onGameOver = value; } }

        public float RotSpeed { get => _rotSpeed; set { _rotSpeed = value; } }

        private void Start()
        {
            onRoadCant = true; //Active Road Cant
            startRotSpeed = _rotSpeed;
            minCant = _xRot.rotation;
            onGameOver = false;
        }

        void Update()
        {
            RoadRotation();
            RoadCant();
        }

        public void ResetSpeed()
        {
            _rotSpeed = startRotSpeed;
        }

        void RoadRotation()
        {
            if (!onGameOver) transform.RotateAround(transform.position, Vector3.up, _rotSpeed * Time.deltaTime);
        }

        void RoadCant() //Variation in the Inclination of the Road
        {
            if (!onGameOver && onRoadCant) SinusoidalHRot();
        }

        private void SinusoidalHRot()
        {
            onRoadCant = false;
            StartCoroutine(LerpRotation(minCant, Quaternion.Euler(_maxCant), _transTime));
        }

        void SwitchTarget()
        {
            _maxCant = minCant.eulerAngles;
            minCant = _xRot.rotation;   
        }

        IEnumerator LerpRotation(Quaternion start, Quaternion target, float lerpDuration)
        {
            float timeElapsed = 0f;

            while(timeElapsed < lerpDuration)
            {
                _xRot.rotation = Quaternion.Lerp(start, target, smoothCant.Evaluate(timeElapsed / lerpDuration));
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            _xRot.rotation = target;
            SwitchTarget();
        }
    }
}
