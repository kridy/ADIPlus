using ADIPlus.Drawing;
using MinECS;


internal class Program
{
    private static void Main(string[] args)
    {
        var gameState = new GameState();

        var engienState = new EngienState(60, Console.WindowWidth, Console.WindowHeight);
        var renderEngien = new RenderEngien(engienState);
        var updateEngien = new UpdateEngien();
        var gameEngien = new GameEngien(
            engienState, 
            gameState, 
            renderEngien, 
            updateEngien);

        World.Create("snake")
            .Add(new TranslationComponent(10, 15, 5, 5, 1, 0))
            .Add(new RenderComponent(DrawLib.SnakeImageGen))
            .Add(new PlayerInputComponent())
            .Add(new AABBColliderComponent(0,0,1,1));

        World.Create("apple")
            .Add(new TranslationComponent(50, 15, 0, 0, 0, 0))
            .Add(new RenderComponent(DrawLib.AppelImageGen))
            .Add(new AABBColliderComponent(0, 0, 1, 1));

        World.Create("apple2")
            .Add(new TranslationComponent(60, 15, 0, 0, 0, 0))
            .Add(new RenderComponent(DrawLib.AppelImageGen));       


        gameEngien.Start();
    }
}

