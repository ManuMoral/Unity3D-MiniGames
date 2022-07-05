using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    public GameObject wallPrefab;
    public int counter = 0;

    Vector3 origin = new Vector3(0, 1, -7);

    void Start()
    {
        
    }

    void Update()
    {
        if( counter < 10 ) {
            if( Input.GetKeyDown( KeyCode.Space ) ) {
                // Instantiate( prefabObject, newPosition, newRotation );
                Instantiate( wallPrefab, origin, Quaternion.identity );

                //counter = counter + 1;
                //counter += 1;
                counter++;
            }
        }
    }
}
