using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    Transform arrowOrigin;
    
    int arrows = 0;

    void Update()
    {
        // if( arrows < 9 ) {
            if( Input.GetKeyDown( KeyCode.V ) ) {
                Instantiate(arrow, arrowOrigin.position, Quaternion.Euler(0, 90, 0));

                arrows++;
            }
        // }
    }
}
