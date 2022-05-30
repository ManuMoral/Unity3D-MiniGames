//Exercise 4: Quantum Pong
//Editor: Manu Moral

namespace Unity3DMiniGames
{
    public class PlayerTwoMov : PlayersMov
    {
  
        private void Update()
        {
            MovController("Vertical2", transform.position, m_currentSpeed, m_currentYBound);
        }
    }
}

