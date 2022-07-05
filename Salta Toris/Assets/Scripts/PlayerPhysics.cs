//Exercise: Salta Tori
//editor: Manu Moral

using TMPro;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _toriCount;
    
    [SerializeField] bool isGrounded;
    int toriCount;
    [SerializeField] float jumpForce;

    bool isJump, isCrouched;

    Rigidbody rb;
    CapsuleCollider capCol;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        toriCount = 0;
        _toriCount.text = toriCount.ToString();
    }

    private void Update()
    {
        ReadInput();
        Crouch();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) isJump = true;
    }

    void Jump()
    {
        if (isJump && !isCrouched)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = false;
        }    
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isJump)
        {
            capCol.height = .5f;
            isCrouched = true;
            isJump = false;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            capCol.height = 2f;
            isCrouched = false;
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tori"))
        {
            toriCount++;
            _toriCount.text = toriCount.ToString();
        }
        else if (other.CompareTag("DoubleTori"))
        {
            toriCount += 2;
            _toriCount.text = toriCount.ToString();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
