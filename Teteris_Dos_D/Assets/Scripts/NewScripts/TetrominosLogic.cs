//Teteris MiniGame
//Editor: Manu Moral

using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityMiniGames
{
    public class TetrominosLogic : MonoBehaviour
    {
        float previousTime;
        [SerializeField] float _fallTime = 1f;
        public static int m_gridHeight = 20, m_gridWidth = 10, m_score = 0, m_diffLevel = 0;
        [SerializeField] Vector3 _rotationPoint;
        static Transform[,] grid = new Transform[m_gridWidth, m_gridHeight];

        [SerializeField] AudioClip[] _sounds;
        AudioSource audioSRC;

        private void Awake()
        {
            audioSRC = GetComponent<AudioSource>();
        }

        private void Update()
        {
            HorizontalMov();
            FallMov();
            RotateTetromino();
            SetDiffLevel();
            IncreaseDiffSpeed();
        }

        private void RotateTetromino()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.RotateAround(transform.TransformPoint(_rotationPoint), Vector3.forward, -90);
                audioSRC.PlayOneShot(_sounds[0], 1f); //SoundFX of Rotation
                if (!Limits()) transform.RotateAround(transform.TransformPoint(_rotationPoint), Vector3.forward, 90);
            }
        }

        private void FallMov()
        {
            if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? _fallTime / 20 : _fallTime))
            {
                transform.position += Vector3.down;
                if (!Limits())
                {
                    transform.position -= Vector3.down;
                    AddToGrid();
                    CheckLines();
                    audioSRC.PlayOneShot(_sounds[1], 1f); //SoundFX to Place 
                    audioSRC.PlayOneShot(_sounds[3], .5f);
                    this.enabled = false;
                    FindObjectOfType<GeneratorLogic>().NewTetromino();
                }

                previousTime = Time.time;
            }
        }

        private void HorizontalMov()
        {
            if (Input.GetKeyDown(KeyCode.A)) //Left
            {
                transform.position += Vector3.left;
                if (!Limits()) transform.position -= Vector3.left;
            }

            if (Input.GetKeyDown(KeyCode.D)) //Right
            {
                transform.position += Vector3.right;
                if (!Limits()) transform.position -= Vector3.right;
            }
        }

        bool Limits() //We set the movements limits according to the grid of the board
        {
            foreach (Transform child in transform)
            {
                int axisX = Mathf.RoundToInt(child.transform.position.x);
                int axisY = Mathf.RoundToInt(child.transform.position.y);
                if (axisX < 0 
                    || axisX >= m_gridWidth 
                    || axisY < 0 
                    || axisY >= m_gridHeight) return false;

                if (grid[axisX, axisY] != null) return false;
            }

            return true;
        }

        void AddToGrid() //Add the position of each Tetrimino's Child
        {
            foreach (Transform child in transform)
            {
                int axisX = Mathf.RoundToInt(child.transform.position.x);
                int axisY = Mathf.RoundToInt(child.transform.position.y);

                grid[axisX, axisY] = child;

                if (axisY >= 19) //Game Over
                {
                    m_score = 0;
                    m_diffLevel = 0;
                    _fallTime = 0;
                    FindObjectOfType<ScoreLogic>().UpdateScores(m_score);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        void CheckLines() //Check if a line was completed
        {
            for (int i = m_gridHeight - 1; i >= 0; i--) //Go through the lines
            {
                if (HaveCompletedLine(i))
                {
                    DeleteLine(i);
                    ToGoDownLine(i);
                }
            }
        }

        bool HaveCompletedLine(int i) //True if a line was completed
        {
            for (int j = 0; j < m_gridWidth; j++) //Go through each square in the columns
            {
                if (grid[j, i] == null) return false;
            }
            m_score += 100;
            audioSRC.PlayOneShot(_sounds[2], 1f); //SoundFX of Line Completed
            FindObjectOfType<ScoreLogic>().UpdateScores(m_score);
            return true;
        }

        void DeleteLine(int i) //Delete that line 
        {
            for (int j = 0; j < m_gridWidth; j++) 
            {
                Destroy(grid[j, i].gameObject);
                grid[j, i] = null;
            }
        }

        void ToGoDownLine(int i) //Go down the lines that are above
        {
            for (int k = i; k < m_gridHeight; k++) 
            {
                for (int j = 0; j < m_gridWidth; j++) 
                {
                    if (grid[j,k] != null)
                    {
                        grid[j, k - 1] = grid[j, k];
                        grid[j, k] = null;
                        grid[j, k - 1].transform.position -= Vector3.up;
                    }
                }
            }
        }

        void SetDiffLevel()
        {
            switch (m_score)
            {
                case 200:
                    m_diffLevel = 1;
                    break;
                case 400:
                    m_diffLevel = 2;
                    break;
                case 600:
                    m_diffLevel = 3;
                    break;
                case 800:
                    m_diffLevel = 4;
                    break;
                case 1000:
                    m_diffLevel = 5;
                    break;
                case 2000:
                    m_diffLevel = 6;
                    break;

            }
        }

        void IncreaseDiffSpeed()
        {
            switch (m_diffLevel)
            {
                case 1:
                    _fallTime = 1;
                    break;
                case 2:
                    _fallTime = .9f;
                    break;
                case 3:
                    _fallTime = .8f;
                    break;
                case 4:
                    _fallTime = .6f;
                    break;
                case 5:
                    _fallTime = .4f;
                    break;
                case 6:
                    _fallTime = .2f;
                    break;

            }
        }
    }
}


