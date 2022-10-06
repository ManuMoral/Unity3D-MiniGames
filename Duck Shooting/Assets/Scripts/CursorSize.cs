//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity3DMiniGames
{
    public class CursorSize : MonoBehaviour
    {
        [SerializeField] Transform _shootCursor;
        
        void Update()
        {
            //ModifyCursor();
        }

        private void FixedUpdate()
        {
            UpdateCursor();
        }

        private void UpdateCursor()
        {
            if (Input.mousePosition.y <= -1 && Input.mousePosition.y > -5)
            {
                _shootCursor.localPosition = new Vector3(0f, -2f, 18f);
                _shootCursor.localScale = new Vector3(.3f, .3f, .3f);
                Debug.Log("Cerca");
            }
            else if (Input.mousePosition.y <= -5 && Input.mousePosition.y > -10)
            {
                _shootCursor.localPosition = new Vector3(0f, -2f, 26f);
                _shootCursor.localScale = new Vector3(.2f, .2f, .2f);
                Debug.Log("En Patos");
            }
            else if (Input.mousePosition.y <= -10 && Input.mousePosition.y > -25)
            {
                _shootCursor.localPosition = new Vector3(0f, -2f, 26f);
                _shootCursor.localScale = new Vector3(.2f, .2f, .2f);
                Debug.Log("En Patos");
            }
        }

        private void ModifyCursor()
        {
            if (transform.localRotation.x > -10)
            {
                _shootCursor.localPosition = new Vector3(0f, -2f, 35f);
                _shootCursor.localScale = new Vector3(.1f, .1f, .1f);
                Debug.Log("Lejos");
            }
            else if (transform.localRotation.x > -5 && transform.localRotation.x < -10)
            {
                _shootCursor.localPosition = new Vector3(0f, -2f, 26f);
                _shootCursor.localScale = new Vector3(.2f, .2f, .2f);
                Debug.Log("En Patos");
            }
            else if (transform.localRotation.x < -5)
            {
                _shootCursor.localPosition = new Vector3(0f, -2f, 18f);
                _shootCursor.localScale = new Vector3(.3f, .3f, .3f);
                Debug.Log("Cerca");
            }
        }
    }
}

