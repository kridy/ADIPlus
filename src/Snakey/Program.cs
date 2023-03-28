using ADIPlus.Drawing;
using MinECS;
using System.Numerics;
using System.Transactions;

internal class Program
{
    public static void SnakeImageGen(AsciiGraphics surface, GameObject gameObject)
    {
        var translate = ComponentManager.GetComponent<TranslationComponent>(gameObject);

        if (translate == null)
            throw new Exception($"Componen of type {typeof(TranslationComponent).Name} is missing from {gameObject.Id}");

        surface.DrawPoint(new AsciiPen('*', AsciiColors.Green), new Point((uint)translate!.Location.X, (uint)translate!.Location.Y));
    }

    public static void AppelImageGen(AsciiGraphics surface, GameObject gameObject)
    {
        var translate = ComponentManager.GetComponent<TranslationComponent>(gameObject);

        if (translate == null)
            throw new Exception($"Componen of type {typeof(TranslationComponent).Name} is missing from {gameObject.Id}");

        surface.DrawPoint(new AsciiPen("O", AsciiColors.Green), new Point((uint)translate!.Location.X, (uint)translate!.Location.Y));
    }


    private static void Main(string[] args)
    {
        var gameState = new GameState();

        var engienState = new EngienState(160, Console.WindowWidth, Console.WindowHeight);
        var renderEngien = new RenderEngien(engienState);
        var updateEngien = new UpdateEngien();
        var gameEngien = new GameEngien(
            engienState, 
            gameState, 
            renderEngien, 
            updateEngien);

        var world = new World();
        world.Create("snake")
            .Add(new TranslationComponent(10, 15, 5, 5, 1, 0))
            .Add(renderEngien.Create(SnakeImageGen))
            .Add(new ConsumerComponent())
            .Add(new PlayerComponent());


        world.Create("snake1")
            .Add(new TranslationComponent(55, 15, 5, 5, 1, 0))
            .Add(renderEngien.Create(SnakeImageGen))
            .Add(new ConsumerComponent())
            .Add(new SimpleAIComponent());


        world.Create("apple")
            .Add(new TranslationComponent(50, 15, 0, 0, 0, 0))
            .Add(renderEngien.Create(AppelImageGen))
            .Add(new ConsumableComponent());

        world.Create("apple2")
            .Add(new TranslationComponent(60, 15, 0, 0, 0, 0))
            .Add(renderEngien.Create(AppelImageGen));





        gameEngien.Start();
    }
}

