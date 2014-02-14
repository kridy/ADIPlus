using System.Threading;

namespace Snake
{
    /// <summary>
    /// Vary vary basic gameloop
    /// </summary>
    internal class GameLoop
    {
        private readonly Game _game;

        public GameLoop(Game game)
        {
            _game = game;
        }

        public void Start()
        {
            _game.Start();
            while (_game.Started)
            {
                _game.Input();
                _game.Update();
                _game.Render();

                Thread.Sleep(100);
            }
        }
    }
}