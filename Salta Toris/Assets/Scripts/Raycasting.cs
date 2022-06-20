//Exercise: Salta Tori
//Editor: Manu Moral

using UnityEngine;

public class Raycasting : MonoBehaviour
{

    Ray ray;
    [SerializeField] LayerMask _layerMask;
    readonly float maxDistance = 50f, duration = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Generate a Ray from the Main Camera to mouse position:
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitData;

            //If the Ray hit something whith Tag "Destructible":
            if (Physics.Raycast(ray, out hitData, maxDistance, _layerMask))
            {
                if (hitData.collider.CompareTag("Destructible"))
                {
                    Destroy(hitData.transform.gameObject);
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, duration);
        }
    }
}
