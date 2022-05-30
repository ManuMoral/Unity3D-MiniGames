//Exercise 4: Quantum Pong
//Editor: Manu Moral

namespace Unity3DMiniGames
{
    public class PlayerOneMov : PlayersMov
    {

        private void Update()
        {
            MovController("Vertical",transform.position, m_currentSpeed, m_currentYBound);
        }
    }
}

