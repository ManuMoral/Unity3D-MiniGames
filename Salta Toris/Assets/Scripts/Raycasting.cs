//Exercise: Salta Tori
//Editor: Manu Moral

using UnityEngine;
using TMPro;

public class Raycasting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _duckCount;
    Ray ray;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] PlayerMove _pCamMove;
    readonly float maxDistance = 50f, duration = 5f;
    bool isShooting;
    int duckCount;

    private void Start()
    {
        duckCount = 0;   
    }

    void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    void ReadInput()
    {
        if (Input.GetMouseButtonDown(0) && _pCamMove.m_isOnFPCam) isShooting = true;
    }

    private void Shoot()
    {
        if (isShooting)
        {
            //Generate a Ray from the Main Camera to mouse position:
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //If the Ray hit something whith Tag "Destructible":
            if (Physics.Raycast(ray, out RaycastHit hitData, maxDistance, _layerMask))
            {
                if (hitData.collider.CompareTag("Destructible"))
                {
                    Destroy(hitData.transform.gameObject);
                }
                if (hitData.collider.CompareTag("LiveDuck"))
                {
                    duckCount++;
                    _duckCount.text = duckCount.ToString();
                    Destroy(hitData.transform.gameObject);
                }
                if (hitData.collider.CompareTag("SuperDuck"))
                {
                    duckCount += 2;
                    _duckCount.text = duckCount.ToString();
                    Destroy(hitData.transform.gameObject);
                }

            }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, duration);
            isShooting = false;
        }
    }

}
