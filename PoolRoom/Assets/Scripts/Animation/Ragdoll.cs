using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Animator animator;
    AnimationController animatorController;

    Rigidbody[] rigidbodies;
    
    CharacterController characterController;
    CharacterControllerMovement characterMovement;

    bool animationEnabled = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorController = GetComponent<AnimationController>();

        rigidbodies = GetComponentsInChildren<Rigidbody>();

        characterController = GetComponentInParent<CharacterController>();
        characterMovement = GetComponentInParent<CharacterControllerMovement>();

        // It's alive!! (no ragdoll)
        ToggleRagdoll();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleRagdoll();
        }
    }

    void ToggleRagdoll()
    {
        // Set animation state
        animationEnabled = !animationEnabled;

        // Enable/disable rigidbodies
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = animationEnabled;
        }

        // Enable/disable animator
        animator.enabled = animationEnabled;
        animatorController.enabled = animationEnabled;

        // Enable/disable character controlling
        characterController.enabled = animationEnabled;
        characterMovement.enabled = animationEnabled;
    }
}