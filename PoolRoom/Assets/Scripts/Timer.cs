using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float totalTime = 0;
    float seconds = 0;

    void FixedUpdate()
    {
        // Debug.Log(Time.fixedDeltaTime); // 0.02
        totalTime += Time.fixedDeltaTime;

        if(totalTime - Mathf.Floor(totalTime) == 0)
        {
            seconds++;

            // Debug.Log(seconds);
        }
    }

    void Update()
    {
        // Debug.Log(Time.deltaTime);
    }

    void LateUpdate()
    {
        // ...
    }
}
