using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    const float GRAVITY = 9.81f;
    const float JUMP_HEIGHT = 1.0f;

    float speed = 2.0f;
    float movementY = 0;
    
    CharacterController characterController;
    
    public bool onGround = false;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --------- Movement on ground ---------

        // If running...
        speed = Input.GetKey(KeyCode.LeftShift) ? 4 : 2;

        Vector3 translationX = Input.GetAxis("Horizontal") * transform.right * speed; // (X, 0, 0)
        Vector3 translationZ = Input.GetAxis("Vertical") * transform.forward * speed; // (0, 0, Z)
        
        // --------- Jump & gravity movement ---------

        onGround = characterController.isGrounded;
        
        // Stop falling on ground
        if (onGround && movementY < 0)
        {
            movementY = 0;
        }

        // Jump impulse
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            movementY += Mathf.Sqrt(JUMP_HEIGHT * GRAVITY * 2);
        }
        
        // Gravity effect
        movementY -= GRAVITY * Time.deltaTime;

        Vector3 translationY = new Vector3(0, movementY, 0); // (0, Y, 0)

        // --------- Do the calculated movement ---------
    
        Vector3 movement = translationX + translationY + translationZ; // (X, Y, Z)
        
        characterController.Move(movement * Time.deltaTime);
    }
}
