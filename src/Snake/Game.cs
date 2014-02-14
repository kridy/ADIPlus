namespace Snake
{
    internal abstract class Game
    {
        public bool Started { get; set; }

        public abstract void Update();

        public abstract void Render();

        public abstract void Input();

        public abstract void Start();
    }
}