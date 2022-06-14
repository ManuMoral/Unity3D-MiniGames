using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStickMov : MonoBehaviour
{
    [SerializeField] float _zForce;
    Rigidbody _cueStick;

    private void Awake()
    {
        _cueStick = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnlockStick();
            _cueStick.AddForce(new Vector3(0f, 0f, _zForce), ForceMode.Impulse);
            Invoke(nameof(StopStick),.1f);
        }
    }

    void StopStick()
    {
        _cueStick.constraints = RigidbodyConstraints.FreezeAll;
    }

    void UnlockStick()
    {
        _cueStick.constraints = RigidbodyConstraints.FreezeRotation;
        _cueStick.constraints = RigidbodyConstraints.FreezePositionX;
        _cueStick.constraints = RigidbodyConstraints.FreezePositionY;
    }

}
