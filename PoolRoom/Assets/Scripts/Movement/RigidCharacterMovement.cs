using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidCharacterMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    
    [SerializeField]
    float jumpSpeed = 4500.0f;

    bool onGround = true;
    
    void Update()
    {
        float translationZ = Input.GetAxis("Vertical") * speed;
        float translationX = Input.GetAxis("Horizontal") * speed;

        translationZ *= Time.deltaTime;
        translationX *= Time.deltaTime;

        transform.Translate(translationX, 0, translationZ);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            gameObject
                .GetComponent<Rigidbody>()
                .AddForce(Vector3.up * jumpSpeed);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
