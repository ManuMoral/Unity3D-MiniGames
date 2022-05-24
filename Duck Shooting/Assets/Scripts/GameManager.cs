//Exercise 3: Duck Shooting
//Editor: Manu Moral

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity3DMiniGames
{
    public class GameManager : MonoBehaviour
    {
        public int m_newScore;
        public bool m_playPause;

        //Singleton:
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        AudioSource _cursorCuack;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);

            m_playPause = false;
            _cursorCuack = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _cursorCuack.Play();
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadGamePlayScene()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadEndGameScene()
        {
            SceneManager.LoadScene(2);
        }
    }
}

