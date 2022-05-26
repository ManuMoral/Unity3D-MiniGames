//Exercise 4: Quantum Pong
//Editor: Manu Moral

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity3DMiniGames
{
    public class MMenuManager : MonoBehaviour
    {

        public void PlayP1VsP2()
        {
            SceneManager.LoadScene(1);
        }

        public void PlayVsCPU()
        {
            SceneManager.LoadScene(2);
        }

        public void Play4Players()
        {
            //Load 4P Scene
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

