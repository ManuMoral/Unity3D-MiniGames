//Exercise: Salta Tori
//editor: Manu Moral

using TMPro;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _toriCount;
    Rigidbody rb;
    [SerializeField] bool isGrounded;
    int toriCount;
    [SerializeField] float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        toriCount = 0;
        _toriCount.text = toriCount.ToString();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) Jump();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
