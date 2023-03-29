using MinECS;

using System.Numerics;

public class PlayerInputSystem
{
    private static readonly Vector2 up = new Vector2(0, -1);
    private static readonly Vector2 down = new Vector2(0, 1);
    private static readonly Vector2 left = new Vector2(-1, 0);
    private static readonly Vector2 right = new Vector2(1, 0);

    public void Update(double delta)
    {
        ConsoleKeyInfo? input = null;

        if (Console.KeyAvailable)
            input = Console.ReadKey(true);

        var playerInputs = ComponentManager.GetActiveComponents<PlayerInputComponent>();

        for (int i = 0; i < playerInputs.Length; i++)
        {
            var playerInput = playerInputs[i];
            var translation = ComponentManager.GetComponent<TranslationComponent>(playerInput.Owner);

            if (translation == null)
                return;
            
            switch (input?.Key)
            {
                case ConsoleKey.UpArrow:
                    translation.Direction = up;
                    break;
                case ConsoleKey.DownArrow:
                    translation.Direction = down;
                    break;
                case ConsoleKey.LeftArrow:
                    translation.Direction = left;
                    break;
                case ConsoleKey.RightArrow:
                    translation.Direction = right;
                    break;
                //    case ConsoleKey.Escape:
                //        gameState.GameOver = true;
                //        break;
                default:
                    break;
            }
        }                   
    }
}


















