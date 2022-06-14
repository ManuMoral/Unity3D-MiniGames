//Exercise: Salta Tori
//Editor: Manu Moral

using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] Transform _playerCam;
    [SerializeField] Camera _firstPCam, _thirdPCam, _cenitalCam;
    [SerializeField] AudioListener _firstCamALis, _thirdCamALis, _cenitalCamALis;
    [SerializeField] float _speed;
    
    [SerializeField] Rigidbody _bodyPlayer;
    float moveX, moveZ, mouseX, mouseY, sensitivity = 2;
    

    private void Start()
    {
        _firstPCam.enabled = true;
        _firstCamALis.enabled = true;
        _thirdPCam.enabled = false;
        _thirdCamALis.enabled = false;
        _cenitalCam.enabled = false;
        _cenitalCamALis.enabled = false;
    }

    void Update()
    {
        ViewRotations();
        CharacterMovement();
        
        if (Input.GetMouseButtonDown(2)) //Center Button
        {
            _firstPCam.enabled = true;
            _firstCamALis.enabled = true;
            _thirdPCam.enabled = false;
            _thirdCamALis.enabled = false;
            _cenitalCam.enabled = false;
            _cenitalCamALis.enabled = false;
        }
        if (Input.GetMouseButtonDown(1)) //Right Button
        {
            _firstPCam.enabled = false;
            _firstCamALis.enabled = false;
            _cenitalCam.enabled = true;
            _cenitalCamALis.enabled = true;
            _thirdPCam.enabled = false;
            _thirdCamALis.enabled = false;
        }
        if (Input.GetMouseButtonDown(0)) //Left Button
        {
            _firstPCam.enabled = false;
            _firstCamALis.enabled = false;
            _cenitalCam.enabled = false;
            _cenitalCamALis.enabled = false;
            _thirdPCam.enabled = true;
            _thirdCamALis.enabled = true;
        }

    }

    void CharacterMovement()
    {
        moveX = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        moveZ = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        transform.Translate(moveZ, 0, moveX);
    }

    void ViewRotations()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;

        transform.localEulerAngles = new Vector3(0, mouseX, 0);

        _playerCam.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }

}
