//Exercise: Salta Tori
//Editor: Manu Moral

using UnityEngine;

public class DuckMov : MonoBehaviour
{
    [SerializeField] Vector3 _startPos;
    [SerializeField] float _reSpawnPoint, _movSpeed;

    bool _isMoving;

    private void Start()
    {
        _isMoving = true;
    }

    void Update()
    {
        DuckMovement();
    }

    private void DuckMovement()
    {
        if (transform.position.x < _reSpawnPoint)
        {
            _isMoving = false;
        }

        if (!_isMoving)
        {
            transform.position = _startPos;
            _isMoving = true;
        }
        else
        {
            transform.Translate(_movSpeed * Time.deltaTime * Vector3.forward);
        }

    }

}
