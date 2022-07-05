using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Transform destiny;
    
    void OnTriggerEnter(Collider character)
    {
        character.gameObject.transform.position = destiny.position;
    }
}
