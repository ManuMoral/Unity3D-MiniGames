//Exercise 2: PoolRoom
//Manu Moral

using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    [SerializeField] GameObject[] _wayPoints;
    [SerializeField] float _speed;
    int wpIndex;

    private void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (Vector3.Distance(transform.position, _wayPoints[wpIndex].transform.position)< 0.1f)
        {
            wpIndex++;

            if (wpIndex >= _wayPoints.Length)
            {
                wpIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[wpIndex].transform.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        col.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision col)
    {
        col.gameObject.transform.SetParent(null);
    }
}
