//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace Unity3DMiniGames
{
    public class DuckPointsCanvas : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _duckPointsText;
        [SerializeField] float _speed;

        private void Start()
        {
            Destroy(gameObject, 3f);
        }


        void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.up);
        }

        public void AddPoints(int points)
        {
            _duckPointsText.color = new Color(1f, 0.75f, 0f, 1f);
            _duckPointsText.text = "+ " + points.ToString() + " p";
        }

        public void SubsPoints(int points)
        {
            _duckPointsText.color = new Color(1f, 0f, 0.1f, 1f);
            _duckPointsText.text = "- " + points.ToString() + " p";
        }
    }

}

