//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using System.Collections;

namespace Unity3DMiniGames
{
    public class BonusBalloon : MonoBehaviour
    {
        [SerializeField] float _speed, _amplitude, _frequency;
        float xPos, counter, xSin;

        private void Start()
        {
            xPos = transform.position.x;
        }

        void Update()
        {
            SinusoidalHMov();

            transform.Translate(_speed * Time.deltaTime * Vector3.up);
        }

        private void SinusoidalHMov()
        {
            counter += _frequency / 100;
            xSin = Mathf.Sin(counter);
            transform.position = new Vector3(xPos + (xSin * _amplitude), transform.position.y, transform.position.z);
            if (counter > 6.28f) counter = 0;
        }
    }
}
