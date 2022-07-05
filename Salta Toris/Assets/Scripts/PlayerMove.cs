//Exercise: Salta Tori
//Editor: Manu Moral

using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] Transform _playerCam;
    [SerializeField] GameObject _firstPCamGun, _thirdPCamGun;
    [SerializeField] Camera _firstPCam, _thirdPCam;
    [SerializeField] AudioListener _firstCamALis, _thirdCamALis;
    [SerializeField] float _speed, _runSpeed;
    
    [SerializeField] Rigidbody _bodyPlayer;
    float startSpeed, moveX, moveZ, mouseX, mouseY, sensitivity = 2;
    [HideInInspector] public bool m_isOnFPCam;

    private void Start()
    {
        _firstPCam.enabled = true;
        _firstCamALis.enabled = true;
        _thirdPCam.enabled = false;
        _thirdCamALis.enabled = false;
        _thirdPCamGun.SetActive(false);
        m_isOnFPCam = true;
        startSpeed = _speed;
    }

    void Update()
    {
        ViewRotations();
        CharacterMovement();
        RunSpeed();
        ChangeCamMode();
        ShowGun();
    }

    void RunSpeed()
    {
        if (Input.GetMouseButton(2))
        {
            _speed = _runSpeed;
        }
        else
        {
            _speed = startSpeed;
        }
    }

    private void ChangeCamMode()
    {
 
        if (Input.GetMouseButtonDown(1)) //Right Button
        {

            _firstPCam.enabled = !_firstPCam.enabled;
            _firstCamALis.enabled = !_firstCamALis.enabled;
            _thirdPCam.enabled = !_thirdPCam.enabled;
            _thirdCamALis.enabled = !_thirdCamALis.enabled;

            m_isOnFPCam = !m_isOnFPCam;
            _bodyPlayer.gameObject.GetComponent<Transform>().localPosition = Vector3.zero;
        }
    }

    void ShowGun()
    {
        if (m_isOnFPCam)
        {
            _firstPCamGun.SetActive(true);
            _thirdPCamGun.SetActive(false);
        }
        else
        {
            _firstPCamGun.SetActive(false);
            _thirdPCamGun.SetActive(true);
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
