using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Raycasting : MonoBehaviour
{
    Ray ray;

    [SerializeField]
    LayerMask layerMask;
    //int layerMask = 1<<3;

    void Start()
    {
        // Creates a Ray from the character to forward
        // ray = new Ray(transform.position, transform.forward);
    }
    
    // void FixedUpdate() {

    // }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray = new Ray(transform.position, transform.forward);

            RaycastHit hitData;

            // If the Ray hit something...
            if (Physics.Raycast(ray, out hitData, 50, layerMask))
            {
                Debug.Log(hitData.transform.position);
                // Debug.Log(hitData.hitDistance);

                if (hitData.collider.tag == "Destructible")
                {                    
                    Destroy(hitData.transform.gameObject);
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray, 50);

            if (hits.Length > 0) {
                foreach (RaycastHit hit in hits)
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
