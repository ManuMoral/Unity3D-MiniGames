using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExampleWall : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {   
        // Reproducir sonido
        /*
        GameObject external = other.gameObject;
        AudioSource audioExternal = external.GetComponent<AudioSource>();
        audioExternal.Play();
        */
        
        other.gameObject.GetComponent<AudioSource>().Play();

        // Decirle al otro objeto que se mueva a la derecha
        other.gameObject.GetComponent<CollisionExampleBall>().movement = Vector3.right; // (1, 0, 0)
    }
}
