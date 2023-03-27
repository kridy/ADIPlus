using System.Numerics;

public class InputEngien
{
    private static readonly Vector2 up    = new Vector2(0, -1);
    private static readonly Vector2 down  = new Vector2(0, 1);
    private static readonly Vector2 left  = new Vector2(-1, 0);
    private static readonly Vector2 right = new Vector2(1, 0);
    
    public void Input(EngienState engienState, GameState gameState)
    {
        //ConsoleKeyInfo? input = null;

        //if (Console.KeyAvailable)
        //    input = Console.ReadKey(true);

        //switch (input?.Key)
        //{
        //    case ConsoleKey.UpArrow:
        //        gameState.direction = up;
        //        break;
        //    case ConsoleKey.DownArrow:
        //        gameState.direction = down;
        //        break;
        //    case ConsoleKey.LeftArrow:
        //        gameState.direction = left;
        //        break;
        //    case ConsoleKey.RightArrow:
        //        gameState.direction = right;    
        //        break;
        //    case ConsoleKey.D1:
        //        gameState.speed = new Vector2(10.0f, (float)engienState.surfaceAspectRatio * 10.0f);
        //        break;
        //    case ConsoleKey.D2:
        //        gameState.speed = new Vector2(20.0f, (float)engienState.surfaceAspectRatio * 20.0f);
        //        break;
        //    case ConsoleKey.D3:
        //        gameState.speed = new Vector2(30.0f, (float)engienState.surfaceAspectRatio * 30.0f);
        //        break;
        //    case ConsoleKey.D4:
        //        gameState.speed = new Vector2(40.0f, (float)engienState.surfaceAspectRatio * 40.0f);
        //        break;
        //    case ConsoleKey.Escape:
        //        gameState.GameOver = true;
        //        break;
        //    default:
        //        break;
        //}
    }
} 

