using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExampleBall : MonoBehaviour
{
    public Vector3 movement = Vector3.down; // (0, -1, 0)

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(movement * Time.deltaTime);
    }
}
