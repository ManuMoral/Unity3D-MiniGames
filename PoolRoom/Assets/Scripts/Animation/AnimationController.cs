using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    CharacterControllerMovement character;

    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponentInParent<CharacterControllerMovement>();
    }

    void Update()
    {
        // If moving...
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
        {
            // Walking
            animator.SetBool("isWalking", true);

            // Rotate to look
            if (Input.GetAxis("Horizontal") > 0) // Right
            {
                RotateY(90);
            }
            else
            if (Input.GetAxis("Horizontal") < 0) // Left
            {
                RotateY(270);
            }
            else
            if (Input.GetAxis("Vertical") > 0) // Up
            {
                RotateY(0);
            }
            else
            if (Input.GetAxis("Vertical") < 0) // Down
            {
                RotateY(180);
            }

            // If running...
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", true);
            }
            else // Stop walking
            {
                animator.SetBool("isRunning", false);
            }
        }
        else // Idle
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        // If jumping...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);

            Invoke("StopJumping", 1.9f);
        }

        // if (character.onGround)
        // {
        //     animator.SetBool("isJumping", false);
        // }
    }

    void StopJumping()
    {
        animator.SetBool("isJumping", false);
    }

    void RotateY(int angle)
    {
        // If rotating...
        if (transform.eulerAngles.y < angle-25 ||
            transform.eulerAngles.y > angle+25)
        {
            bool clockwise = true;

            switch (angle)
            {
                case 0: // Up
                    if (transform.eulerAngles.y < 180)
                    {
                        clockwise = false;
                    }
                    break;
                case 90: // Right
                    if (transform.eulerAngles.y > 90 &&
                        transform.eulerAngles.y < 270)
                    {
                        clockwise = false;
                    }
                    break;
                case 180: // Down
                    if (transform.eulerAngles.y > 180)
                    {
                        clockwise = false;
                    }
                    break;
                case 270: // Left
                    if (transform.eulerAngles.y < 90 ||
                        transform.eulerAngles.y > 270)
                    {
                        clockwise = false;
                    }
                    break;
                default:
                    break;
            }

            int rotationAngle = clockwise ? 10 : -10;

            transform.eulerAngles += new Vector3(0, rotationAngle, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}
