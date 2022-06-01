//Exercise 2: PoolRoom
//Editor: Manu Moral

using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float _xForce;
    [SerializeField] float _hMovSpeed;
    [SerializeField] GameObject _bowlingPack;
    Vector3 _startPos;
    Rigidbody _SphereRb;
    bool _isLaunched;
    GameObject _lastBowls;

    private void Awake()
    {
        _SphereRb = GetComponent<Rigidbody>();
        _startPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !_isLaunched)
        {
            if (_xForce <= 100)
            {
                _xForce++;
            }
            else
            {
                _xForce = 100;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && !_isLaunched)
        {
            _SphereRb.AddForce(new Vector3(0, 0, _xForce), ForceMode.Impulse);
            _isLaunched = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestoreLaunch();
        }

        if (Input.GetKey(KeyCode.A) && !_isLaunched)
        {
            if (transform.position.x > -6)
            {
                transform.Translate(_hMovSpeed * Time.deltaTime * Vector3.left);
            }
        }

        if (Input.GetKey(KeyCode.D) && !_isLaunched)
        {
            if (transform.position.x < 6)
            {
                transform.Translate(_hMovSpeed * Time.deltaTime * Vector3.right);
            }
        }

        if (Input.GetKey(KeyCode.Q) && !_isLaunched)
        {
            //Rotate the ball to the left
            if (true)
            {

            }

        }

        if (Input.GetKey(KeyCode.E) && !_isLaunched)
        {
            //Rotate the ball to the Right
            if (true)
            {

            }
        }
    }

    void RestoreLaunch()
    {
        _lastBowls = GameObject.FindGameObjectWithTag("BowlingPack");
        Destroy(_lastBowls);
        transform.SetPositionAndRotation(_startPos, Quaternion.Euler(0, 0, 0));
        _SphereRb.constraints = RigidbodyConstraints.FreezeAll;
        _SphereRb.velocity = Vector3.zero;
        _isLaunched = false;
        _SphereRb.constraints = RigidbodyConstraints.None;
        _xForce = 10;
        Instantiate(_bowlingPack, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
