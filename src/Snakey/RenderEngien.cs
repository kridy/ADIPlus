using ADIPlus.Drawing;

using MinECS;

using System.Numerics;

public class RenderEngien
{
    private readonly EngienState _engienState;
    private readonly Image _image;
    private readonly AsciiGraphics _imageGraphics;
    private readonly AsciiGraphics _consoleGraphics;
    private readonly RenderSystem _renderSystem;

    public RenderEngien(EngienState engienState)
    {
        Console.CursorVisible = false;

        _engienState = engienState;

        _image = new Image(_engienState.surfaceWidth, _engienState.surfaceHeight);
        _imageGraphics = AsciiGraphics.FromCharImage(_image);
        _consoleGraphics = AsciiGraphics.FromUnManagedConsole();
        
        _renderSystem = new RenderSystem(_imageGraphics);

    }

    public void Render(double delta)
    {
        _imageGraphics.Clear();

        _renderSystem.Update(delta);

        //_imageGraphics.DrawPoint(new AsciiPen('*', AsciiColors.DarkMagenta), new Point((uint)gameState.Location.X, (uint)gameState.Location.Y));
        //_imageGraphics.DrawString($"FTP: {_engienState.fps} Hz", AsciiColors.Green, 1, 1);
        //_imageGraphics.DrawString($"Loc: ({gameState.Location.X},{gameState.Location.Y})", AsciiColors.Green, 1, 2);
        //_imageGraphics.DrawString($"Dir: ({gameState.direction.X},{gameState.direction.Y})", AsciiColors.Green, 1, 3);
        //_imageGraphics.DrawString($"Spd: ({gameState.speed.X},{gameState.speed.Y})", AsciiColors.Green, 1, 4);
        //
        _consoleGraphics.DrawImage(_image);
    }
}

