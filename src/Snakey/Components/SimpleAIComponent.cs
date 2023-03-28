using System.Diagnostics.Metrics;
using System.Numerics;

using MinECS;

internal class SimpleAIComponent : Component
{
    Random rnd = new Random();
    private static readonly Vector2 up = new Vector2(0, -1);
    private static readonly Vector2 down = new Vector2(0, 1);
    private static readonly Vector2 left = new Vector2(-1, 0);
    private static readonly Vector2 right = new Vector2(1, 0);

    int counter = 0;
    public override void Update(double delta)
    {
        counter = (++counter) % 200;

        var translation = ComponentManager.GetComponent<TranslationComponent>(this.Owner);

        if (translation == null)
            return;

        if (counter == 0)
        {
            switch (rnd.Next(3))

            {
                case 0:
                    translation.Direction = up;
                    break;
                case 1:
                    translation.Direction = down;
                    break;
                case 2:
                    translation.Direction = left;
                    break;
                case 3:
                    translation.Direction = right;
                    break;

                default:
                    break;


            }
        }

    }
}