//Exercise 2: PoolRoom
//Manu Moral

using System.Collections;
using UnityEngine;

public class SphereForce : MonoBehaviour
{
    [SerializeField] float _timeToUnlock, _timeToStop;
    [SerializeField, Range(0, 1000)] float _xForce;
    Rigidbody _SphereRb;

    AudioClip _audioClip;
    AudioSource _audioSrc;

    private void Awake()
    {
        _SphereRb = GetComponent<Rigidbody>();
        _audioClip = Resources.Load("Audio/MetalClick") as AudioClip;
        _audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (CompareTag("Sphere1"))
        {
            _SphereRb.AddForce(new Vector3(-_xForce, 0.0f, 0.0f));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CompareTag("Sphere1"))
        {
            _SphereRb.AddForce(new Vector3(-_xForce, 0.0f, 0.0f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float audioLevel = collision.relativeVelocity.magnitude / 10.0f;
        _audioSrc.PlayOneShot(_audioClip, audioLevel);
    }

    void StopSphere()
    {
        _SphereRb.constraints = RigidbodyConstraints.FreezeAll;
        _SphereRb.velocity = Vector3.zero;
        StartCoroutine(TimeToUnlock());
    }

    IEnumerator TimeToUnlock()
    {
        yield return new WaitForSeconds(_timeToUnlock);
        _SphereRb.constraints = RigidbodyConstraints.None;
    }
}
