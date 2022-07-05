//Practice 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity3DMiniGames
{
    public class BrandTransition : MonoBehaviour
    {
        [SerializeField] GameObject[] _brandVideo;
        [SerializeField] float _delayToPlaySecondBrand, _delayToMainMenu;

        void Start()
        {
            Cursor.visible = false;
            _brandVideo[0].SetActive(true);
            Invoke(nameof(PlaySecondBrand), _delayToPlaySecondBrand);
        }

        void PlaySecondBrand()
        {
            _brandVideo[0].SetActive(false);
            _brandVideo[1].SetActive(true);
            Invoke(nameof(LoadMainMenuScene), _delayToMainMenu);
        }

        void LoadMainMenuScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}

