using System.Numerics;

public class GameState
{
    public GameState()
    {     
    }

    public bool GameOver;
}

public class EngienState
{
    public readonly double surfaceAspectRatio;
    public readonly uint surfaceWidth;
    public readonly uint surfaceHeight;
    public readonly int targetFps;
    public int fps;

    public EngienState(int targetFps, int surfaceWidth, int surfaceHeight)
    {
        this.targetFps = targetFps;
        this.surfaceWidth = (uint)surfaceWidth;
        this.surfaceHeight = (uint)surfaceHeight;

        this.surfaceAspectRatio = (double)surfaceHeight/ (double)surfaceWidth;


    }
}

