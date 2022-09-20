//Teteris MiniGame
//Editor: Manu Moral

using UnityEngine;

namespace UnityMiniGames
{
    public class GeneratorLogic : MonoBehaviour
    {
        [SerializeField] GameObject[] _tetrominos, _nextTetromino;
        [SerializeField] Transform[] _spawnPoints;
        [SerializeField] Transform _nextSP;
        int rngTetromino;

        private void Start()
        {
            rngTetromino = Random.Range(0, _tetrominos.Length);
            NewTetromino();
        }

        public void NewTetromino()
        {
            _nextTetromino[rngTetromino].SetActive(false);
            SpawnTetromino();
            rngTetromino = Random.Range(0, _tetrominos.Length);
            _nextTetromino[rngTetromino].SetActive(true);

        }

        void SpawnTetromino()
        {
            Instantiate(_tetrominos[rngTetromino],
                _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, 
                Quaternion.identity);
        }
    }
}


