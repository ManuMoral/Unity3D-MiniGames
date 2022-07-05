//Exercise 2: PoolRoom
//Manu Moral

using UnityEngine;

public class BotCharacterController : MonoBehaviour
{
    CharacterController charCtrl;

    const float gravity = -9.81f;

    [SerializeField] float _speed, _jumpHeight;

    bool onGround;
    Vector3 hDir, vDir;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    void Update()
    {
        LookAt();
        CharacterController(); 
    }

    private void CharacterController()
    {
        // --------- Horizontal & Vertical Movement ---------

        Vector3 translationX = Input.GetAxis("Horizontal") * hDir;
        Vector3 translationZ = Input.GetAxis("Vertical") * vDir;

        Vector3 move = translationX + translationZ;

        // --------- Jump & gravity movement ---------

        onGround = charCtrl.isGrounded;

        if (onGround && move.y < 0)
        {
            move.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            move.y += Mathf.Sqrt(_jumpHeight * gravity * -2);
        }

        move.y += gravity * Time.deltaTime;

        // --------- Do the calculated movement ---------
        charCtrl.Move(_speed * Time.deltaTime * move);
    }

    void LookAt()
    {
        // Look
        if (Input.GetAxis("Horizontal") > 0) // Right
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            vDir = -transform.right;
        }
        else
        if (Input.GetAxis("Horizontal") < 0) // Left
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
            vDir = transform.right;
        }
        else
        if (Input.GetAxis("Vertical") > 0) // Up
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            hDir = transform.right;
        }
        else
        if (Input.GetAxis("Vertical") < 0)// Down
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            hDir = -transform.right;
        }
    }
}
