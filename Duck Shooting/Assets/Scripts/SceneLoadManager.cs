//Practice 3: Duck Shooting
//Editor: Manu Moral

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity3DMiniGames
{
    public class SceneLoadManager : MonoBehaviour
    {
        Animator transitionAnim;
        AudioSource _audioSRC;
        [SerializeField] AudioClip _whiteNoise;
        [SerializeField] GameObject _pauseUI, _curtains;
        [SerializeField] float _transitionTime;
        [SerializeField] MusicManager _bgMusic;
        bool pauseMenuisVisible;

        void Start()
        {
            if (GameManager.Instance.m_isFirstTrans)
            {
                _curtains.SetActive(false);
            }
            
            transitionAnim = GetComponent<Animator>();
            _audioSRC = GetComponent<AudioSource>();
            pauseMenuisVisible = false;
            //GameManager.Instance.m_isFirstTrans = false;
        }

        private void Update()
        {
            CursorProp();
        }

        private void CursorProp()
        {

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {

                if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.m_playPause)
                {
                    GameManager.PauseGame();
                    _pauseUI.SetActive(true);
                    pauseMenuisVisible = true;
                    _bgMusic.PauseMusic();
                }
                else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.m_playPause && pauseMenuisVisible)
                {
                    _pauseUI.SetActive(false);
                    pauseMenuisVisible = false;
                    GameManager.ResumeGame();
                    _bgMusic.PlayMusic();
                }

                Cursor.visible = false;
            }
            else
            {
                Cursor.visible = true;

                if (Input.GetMouseButtonDown(0) && !GameManager.Instance.m_isSoundOff)
                {
                    _audioSRC.Play();
                }
            }
        }

        public void HidePauseMenu()
        {
            _pauseUI.SetActive(false);
            pauseMenuisVisible = false;
            GameManager.ResumeGame();
            _bgMusic.PlayMusic();
        }

        public void ExitToMainMenu()
        {
            
            GameManager.Instance.m_isGameOver = true;
            _pauseUI.SetActive(false);
            pauseMenuisVisible = false;
            GameManager.ResumeGame();
            StartCoroutine(SceneLoad(1));
        }

        public void PlayCurtainSound()
        {
            if (!GameManager.Instance.m_isSoundOff)
            {
                if (!GameManager.Instance.m_isFirstTrans) _audioSRC.PlayOneShot(_whiteNoise, 1f);
            }
                
        }

        //Scenes:
        //0 : Logos
        //1: Main Menu
        //2: GamePlay
        //3: GameOver

        public IEnumerator SceneLoad(int sceneIndex)
        {
            GameManager.Instance.m_playPause = true;
            GameManager.Instance.m_isFirstTrans = false;
            _bgMusic.StopTheMusic();
            _curtains.SetActive(true);
            //Cast Transition Anim:
            transitionAnim.SetTrigger("StartTransition");
            PlayCurtainSound();
            //Wait to Finish Transition: 
            yield return new WaitForSeconds(_transitionTime);

            if (sceneIndex == 1)
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    GameManager.Instance.m_isGameOver = true;
                    _pauseUI.SetActive(false);
                    pauseMenuisVisible = false;
                    GameManager.ResumeGame();
                }
            }
            else if (sceneIndex == 2)
            {
                GameManager.ResetScores();
                GameManager.Instance.m_isGameOver = false;
                GameManager.Instance.m_speedShootBonusOn = false;
            }

            GameManager.Instance.TurnOnTheScene();
            //Load Scene
            SceneManager.LoadScene(sceneIndex);
        }

    }

    
}


