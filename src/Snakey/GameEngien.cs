using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;

public class GameEngien
{
    private readonly InputEngien _inputEngien;
    private readonly EngienState _engienState;
    private readonly GameState _gameState;

    private readonly RenderEngien _renderEngien;
    private readonly UpdateEngien _updateEngien;
    public GameEngien(EngienState engienState, GameState gameState, RenderEngien renderEngien, UpdateEngien updateEngien)
    {
        _engienState = engienState;
        _gameState = gameState;

        _renderEngien = renderEngien;
        _inputEngien = new InputEngien();
        _updateEngien = updateEngien;
    }

    public void Start()
    {        
        RenderLoop();
    }

    public void RenderLoop()
    {
        double frameTime = 1.0d / (double)_engienState.targetFps; 
        double accumRender = 0;
        double accumFps = 0;
        int countFrame = 0;
        DateTime prev = DateTime.Now;

        while (!_gameState.GameOver)
        {
            var now = DateTime.Now;

            var loopdiff = (now - prev).TotalSeconds;

            accumFps += loopdiff;
            accumRender += loopdiff;
            
            if(accumFps > 1.0d) 
            {
                _engienState.fps = countFrame;
                countFrame = 0;
                accumFps = 0;
            }

            _inputEngien.Input(_engienState, _gameState);

            if(accumRender > frameTime)
            {
                countFrame++;
                _updateEngien.Update(accumRender);
                _renderEngien.Render(accumRender);
                accumRender = 0d;
            }

            prev= now;

            //Thread.Sleep(0);
        }
    }
}

