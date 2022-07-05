//Exercise 2: PoolRoom
//Manu Moral

using UnityEngine;

public class AnimateBotX : MonoBehaviour
{
    Animator anim;
    bool isJumping;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Walk();
        Run();
        Jump();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            anim.SetTrigger("Jump");
            isJumping = true;
            Invoke(nameof(TouchFloor), 2f);
        }
    }

    void TouchFloor()
    {
        isJumping = !isJumping;
    }
}
